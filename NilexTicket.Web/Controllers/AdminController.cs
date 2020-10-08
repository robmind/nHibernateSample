using NilexTicket.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NilexComment.DB.Repositories;
using NilexTicket.DB;
using NilexTicket.DB.Repositories;
using NilexTicket.DB.Repositories.Interfaces;
using NilexTicket.Util;

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

        // GET: /Admin/
        public ActionResult Index()
        {
            var tick = ticketRepository.GetAllTicket();
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
            ViewBag.toplam = tick.Count();

            string kl = Session["Admin"] as string;
            ViewBag.kl = userRepositoty.GetUserByLogin(kl);

            return View();
        }
        public ActionResult Manage()
        {
            ViewBag.admin = Session["Admin"];
            var Userlar = userRepositoty.GetAllUserByRoleId("User");
            ViewBag.Adminler = userRepositoty.GetAllUserByRoleId("Admin");
            return View(Userlar);
        }

        [HttpPost]
        public JsonResult AdminDelete(int id)
        {
            JsonModel Jmodel = new JsonModel();
            try
            {
                var usr = userRepositoty.GetUserByUserId(id);
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
                User usr = userRepositoty.GetUserByUserId(id);
                if (usr != null)
                {
                    userRepositoty.DeleteUserData(usr.ID);
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
            return View();
        }

        public ActionResult Display_Details([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetDetails().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Ticket> GetDetails()
        {
            var tck = ticketRepository.GetAllTicketByIsItRead();
            var ticks = tck.Select(test => {
                test.User = null;
                test.Comment = null;
                return test;
            }).ToList();

            return ticks;
        }

        public JsonResult TicketStatusu(int id)
        {
            Ticket tk = ticketRepository.GetTicketByTicketId(id);
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
            ViewBag.kl = userRepositoty.GetUserByLogin(kl).FullName;
            ViewBag.tck = ticketRepository.GetTicketByTicketId(id);
            var Comments = commentRepository.GetAllCommentByTicketId(id);

            if (ViewBag.tck == null)
            {
                return Redirect(Request.RawUrl);
            }
            return View(Comments);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddComment(Comment yrm)
        {
            try
            {
                Ticket cevap = ticketRepository.GetTicketByTicketId(yrm.TicketID);
                cevap.IsItRead = true;

                string kl = Session["Admin"] as string;
                User us = userRepositoty.GetUserByLogin(kl);
                Comment nYrm = new Comment();
                nYrm.Ticket = cevap;
                nYrm.Ticket.ID = cevap.ID;
                nYrm.CreateDate = DateTime.Now;
                nYrm.User = us;
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
            return View(userRepositoty.GetAllUserByRoleId("User"));
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
                try
                {
                    if (usrGelen == null)
                    {
                        return Json(false);
                    }

                    if (usrGelen.FullName == "" || string.IsNullOrEmpty(usrGelen.FullName))
                    {
                        return Json(false);
                    }

                    if (usrGelen.Username == "" || string.IsNullOrEmpty(usrGelen.Username))
                    {
                        return Json(false);
                    }

                    if (usrGelen.Mail == "" || string.IsNullOrEmpty(usrGelen.Mail))
                    {
                        return Json(false);
                    }

                    if (usrGelen.Password == "" || string.IsNullOrEmpty(usrGelen.Password))
                    {
                        return Json(false);
                    }

                    User checkExistUser = userRepositoty.GetUserByLogin(usrGelen.Username);

                    if (checkExistUser != null)
                    {
                        if (checkExistUser.ID > 0)
                        {
                            return Json(false);
                        }
                    }
                    else
                    {
                        User usrUpdated = new User();
                        usrUpdated.FullName = usrGelen.FullName;
                        usrUpdated.Username = usrGelen.Username;
                        usrUpdated.Mail = usrGelen.Mail;
                        usrUpdated.Password = DESEncrypt.Encrypt(usrGelen.Password);
                        usrUpdated.Role = "User";
                        userRepositoty.Save(usrUpdated);
                        jmodel.IsSuccess = true;
                        jmodel.Message = "Admin";
                    }
                }
                catch (Exception)
                {
                }
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
            var usr = userRepositoty.GetUserByUserId(id);
            UserViewModel uvm = usr;
            return View(uvm);
        }

        [HttpPost]
        public JsonResult UserEdit(UserViewModel usrGelen)
        {
            JsonModel jmodel = new JsonModel();
            try
            {
                User usrUpdated = userRepositoty.GetUserByUserId(usrGelen.ID);
                usrUpdated.FullName = usrGelen.FullName;
                usrUpdated.Username = usrGelen.Username;
                usrUpdated.Password = DESEncrypt.Encrypt(usrGelen.Password);
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
                User usr = userRepositoty.GetUserByUserId(id);
                if (usr != null)
                {
                    userRepositoty.DeleteUser(usr.ID);
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
