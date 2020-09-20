using NilexTicket.ModelView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NilexComment.DB.Repositories;
using NilexTicket.DB;
using NilexTicket.DB.Repositories;
using NilexTicket.DB.Repositories.Interfaces;

namespace NilexTicket.Controllers
{
    public class UserController : Login_UserController
    {
        private IUserRepositoty userRepositoty;
        private ITicketRepository ticketRepository;
        private ICommentRepository commentRepository;
        public UserController()
        {
            userRepositoty = new NHUserRepository();
            ticketRepository = new NHTicketRepository();
            commentRepository = new NHCommentRepository();
        }
        public ActionResult Index()
        {
            string kl = Session["User"] as string;
            var kul = userRepositoty.GetAll().SingleOrDefault(x => x.Username == kl);
            ViewBag.username = kul.FullName;

            var tick = ticketRepository.GetAll().Where(y => y.User.ID == kul.ID).Select(x => new { x.CreateDate, x.Status, x.IsItRead}).ToList();
            int newticket = 0, open = 0, unanswered = 0;
            foreach (var item in tick)
            {
                TimeSpan tp = DateTime.Now - (DateTime)item.CreateDate;
                if (tp.TotalMinutes < 60) newticket++;
                if (item.Status == true) open++;
                if (item.IsItRead == false) unanswered++;
            }
            ViewBag.newticket = newticket;
            ViewBag.open = open;
            ViewBag.unanswered = unanswered;
            ViewBag.toplam = tick.Count;

            return View();
        }
        public ActionResult MyTickets()
        {
            string kul = Session["User"] as string;
            var mod = userRepositoty.GetAll().SingleOrDefault(x => x.Username == kul);
            var ticks = ticketRepository.GetAll().Where(x => x.User.ID == mod.ID).OrderByDescending(k=>k.CreateDate);
            return View(ticks);
        }
        public ActionResult NewTicket()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewTicket(Ticket newticket)
        {
            HttpPostedFileBase file = Request.Files[0];
            string kadi = Session["User"] as string;
            User user = userRepositoty.GetAll().SingleOrDefault(x => x.Username == kadi);
            if (file.ContentLength > 0)
            {
                string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                string uzanti = Path.GetExtension(file.FileName);
                string tamYol = "/Content/img/Ticket/" + DosyaAdi + uzanti;

                file.SaveAs(Server.MapPath(tamYol));
                newticket.ImageUrl = tamYol;
            }
            try
            {
                Ticket tk = new Ticket();
                tk.IsItRead = false;
                tk.Priority = newticket.Priority;
                tk.ImageUrl = newticket.ImageUrl;
                tk.User = user;
                tk.UserID = user.ID;
                tk.Status = true;
                tk.Title = newticket.Title;
                tk.Content = newticket.Content;
                tk.CreateDate = DateTime.Now;
                ticketRepository.Save(tk);
                islem = "1";
                return Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                islem = "0";
                return Redirect(Request.RawUrl);
            }
        }

        static string islem = null;
        public ActionResult ticketCheck()
        {
            if (islem == "1")
                return Json(true, JsonRequestBehavior.AllowGet);
            else if (islem == "0")
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
                return Content("Bos");
        }
        public ActionResult viewTemizle()
        {
            islem = "Bos";
            return Content("true");
        }

        public JsonResult TicketStatusu(int id)
        {
            Ticket tk = ticketRepository.GetAll().SingleOrDefault(x => x.ID == id);
            if ((bool)tk.Status)
            {
                tk.Status = false;
                ticketRepository.Save(tk);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tk.Status = true;
                ticketRepository.Save(tk);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult TicketDetail(int id)
        {
            string kl = Session["User"] as string;
            ViewBag.kl = userRepositoty.GetAll().SingleOrDefault(x => x.Username == kl).FullName;
            ViewBag.tck = ticketRepository.GetAll().SingleOrDefault(x => x.ID == id);
            List<Comment> Comments = commentRepository.GetAll().Where(x => x.Ticket.ID == id).ToList();

            if (ViewBag.tck == null)
            {
                return Redirect(Request.RawUrl);
            }
            return View(Comments);
        }
        public JsonResult AddComment(Comment yrm)
        {
            try
            {
                string kl = Session["User"].ToString();
                User kul = userRepositoty.GetAll().SingleOrDefault(x => x.Username == kl);
                Ticket ticket = ticketRepository.GetAll().SingleOrDefault(x => x.ID == yrm.TicketID);
                Comment Comment = new Comment();
                Comment.CreateDate = DateTime.Now;
                Comment.User = kul;
                Comment.User.ID = kul.ID;
                Comment.Ticket = ticket;
                Comment.Ticket.ID = ticket.ID;
                Comment.Explanation = yrm.Explanation;
                commentRepository.Save(Comment);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        public ActionResult Settings()
        {
            string klSession = (string)Session["User"];
            User data = userRepositoty.GetAll().SingleOrDefault(x => x.Username == klSession);
            if (data != null)
            {
                UserViewModel mdel = data;
                return View(mdel);
            }
            else
                return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public JsonResult Settings(UserViewModel mdl)
        {
            JsonModel Jmodel = new JsonModel();
            try
            {
                string sr = Session["User"] as string;
                User usr = userRepositoty.GetAll().SingleOrDefault(x => x.Username == sr);
                usr.FullName = mdl.FullName;
                usr.Username = mdl.Username;
                usr.Password = mdl.Password;
                usr.Mail = mdl.Mail;
                userRepositoty.Save(usr);

                Jmodel.IsSuccess = true;
                Jmodel.Message = "Update successful";
            }
            catch (Exception ex)
            {
                Jmodel.IsSuccess = false;
                Jmodel.Message = "Error : " + ex.Message;
            }
            return Json(Jmodel, JsonRequestBehavior.AllowGet);
        }
    }
}
