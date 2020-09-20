using NilexTicket.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NilexComment.DB.Repositories;
using NilexTicket.DB;
using NilexTicket.DB.Repositories;
using NilexTicket.DB.Repositories.Interfaces;

namespace NilexTicket.Controllers
{
    public class AdminController : Login_AdminController
    {
        private IUserRepositoty userRepositoty;
        private ITicketRepository ticketRepository;
        private ICommentRepository commentRepository;
        public AdminController()
        {
            userRepositoty = new NHUserRepository();
            ticketRepository = new NHTicketRepository();
            commentRepository = new NHCommentRepository();
        }

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            var tick = ticketRepository.LoadAllPublished().Select(x => new { x.CreateDate, x.Status, x.IsItRead }).ToList();
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

            string kl = Session["Admin"] as string;
            ViewBag.kl = userRepositoty.LoadByLogin(kl);

            return View();
        }
        public ActionResult Manage()
        {
            ViewBag.admin = Session["Admin"];
            var Userlar = userRepositoty.GetAll().Where(x => x.Role == "User").ToList().OrderBy(x => x.Username)
                .ToList();
            ViewBag.Adminler = userRepositoty.GetAll().Where(x => x.Role == "Admin").ToList().OrderBy(x => x.ID)
                .ToList();
            return View(Userlar);
        }

        [HttpPost]
        public JsonResult AdminDelete(int id)
        {
            JsonModel Jmodel = new JsonModel();
            try
            {
                var usr = userRepositoty.GetAll().SingleOrDefault(x => x.ID == id);
                usr.Role = "User";
                userRepositoty.Save(usr);

                Jmodel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Jmodel.IsSuccess = false;
                Jmodel.Message = "Error : " + ex.Message;
            }
            return Json(Jmodel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GivePermission(int id)
        {
            JsonModel jmodel = new JsonModel();
            try
            {
                User usr = userRepositoty.GetAll().SingleOrDefault(x => x.ID == id);
                if (usr != null)
                {
                    var tck = ticketRepository.GetAll().Where(x => x.UserID == id).ToList();
                    if (tck.Count > 0)
                    {
                        foreach (var item in tck)
                        {
                            ticketRepository.Delete(item.ID);
                            var yrm = commentRepository.GetAll().Where(x => x.Ticket.ID == item.ID).ToList();
                            foreach (var item2 in yrm)
                            {
                                commentRepository.Delete(item2.ID);
                            }
                            var File = ticketRepository.GetAll().SingleOrDefault(x => x.ImageUrl == item.ImageUrl);
                            if (File != null)
                            {
                                System.IO.File.Delete(Server.MapPath(File.ImageUrl));
                            }
                        }
                    }
                    usr.Role = "Admin";
                    userRepositoty.Save(usr);
                    jmodel.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                jmodel.IsSuccess = false;
                jmodel.Message = "Error : " + ex.Message;
            }
            return Json(jmodel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Tickets()
        {
            var tck = ticketRepository.GetAll().ToList().OrderByDescending(z => z.Status).ThenBy(x => x.IsItRead);
            return View(tck);
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
            string kl = Session["Admin"] as string;
            ViewBag.kl = userRepositoty.GetAll().SingleOrDefault(x => x.Username == kl).FullName;
            ViewBag.tck = ticketRepository.GetAll().SingleOrDefault(x => x.ID == id);
            var Comments = commentRepository.GetAll().Where(x => x.Ticket.ID == id).ToList();

            if (ViewBag.tck == null)
            {
                return Redirect(Request.RawUrl);
            }
            return View(Comments);
        }
        [HttpPost]
        public JsonResult AddComment(Comment yrm)
        {
            try
            {
                Ticket cevap = ticketRepository.GetAll().SingleOrDefault(x => x.ID == yrm.Ticket.ID);
                cevap.IsItRead = true;

                string kl = Session["Admin"] as string;
                User us = userRepositoty.GetAll().SingleOrDefault(x => x.Username == kl);
                Comment nYrm = new Comment();
                nYrm.Ticket.ID = yrm.Ticket.ID;
                nYrm.CreateDate = DateTime.Now;
                nYrm.User.ID = us.ID;
                nYrm.Explanation = yrm.Explanation;
                commentRepository.Save(nYrm);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }

        }
        public ActionResult UserManage()
        {
            return View(userRepositoty.GetAll().Where(x => x.Role == "User").ToList().OrderBy(y => y.ID));
        }

        public ActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserCreate(UserViewModel usrGelen)
        {
            JsonModel jmodel = new JsonModel();
            try
            {
                User usrUpdated = new User();
                usrUpdated.FullName = usrGelen.FullName;
                usrUpdated.Username = usrGelen.Username;
                usrUpdated.Password = usrGelen.Password;
                usrUpdated.Role = "User";
                usrUpdated.Mail = usrGelen.Mail;
                userRepositoty.Save(usrUpdated);
                jmodel.IsSuccess = true;
                jmodel.Message = "Admin";
            }
            catch (Exception ex)
            {
                jmodel.IsSuccess = false;
                jmodel.Message = "Error : " + ex.Message;
            }
            return Json(jmodel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserEdit(int id)
        {
            var usr = userRepositoty.GetAll().SingleOrDefault(x => x.ID == id);
            UserViewModel uvm = usr;
            return View(uvm);
        }

        [HttpPost]
        public JsonResult UserEdit(UserViewModel usrGelen)
        {
            JsonModel jmodel = new JsonModel();
            try
            {
                User usrUpdated = userRepositoty.GetAll().SingleOrDefault(x => x.ID == usrGelen.ID);
                usrUpdated.FullName = usrGelen.FullName;
                usrUpdated.Username = usrGelen.Username;
                usrUpdated.Password = usrGelen.Password;
                usrUpdated.Mail = usrGelen.Mail;
                userRepositoty.Save(usrUpdated);
                jmodel.IsSuccess = true;
                jmodel.Message = "Admin";
            }
            catch (Exception ex)
            {
                jmodel.IsSuccess = false;
                jmodel.Message = "Error : " + ex.Message;
            }
            return Json(jmodel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult userDelete(int id)
        {
            JsonModel jmodel = new JsonModel();
            try
            {
                User usr = userRepositoty.GetAll().SingleOrDefault(x => x.ID == id);
                if (usr != null)
                {
                    var tck = ticketRepository.GetAll().Where(x => x.UserID == id).ToList();
                    if (tck.Count > 0)
                    {
                        foreach (var item in tck)
                        {
                            ticketRepository.Delete(item.ID);
                            var yrm = commentRepository.GetAll().Where(x => x.Ticket.ID == item.ID).ToList();
                            foreach (var item2 in yrm)
                            {
                                commentRepository.Delete(item2.ID);
                            }
                            var File = ticketRepository.GetAll().SingleOrDefault(x => x.ImageUrl == item.ImageUrl);
                            if (File != null)
                            {
                                System.IO.File.Delete(Server.MapPath(File.ImageUrl));
                            }
                        }
                    }
                    userRepositoty.Save(usr);
                    jmodel.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                jmodel.IsSuccess = false;
                jmodel.Message = "Error : " + ex.Message;
            }
            return Json(jmodel, JsonRequestBehavior.AllowGet);
        }

    }
}
