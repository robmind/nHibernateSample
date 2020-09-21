using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NilexTicket.DB;
using NilexTicket.DB.Repositories;
using NilexTicket.DB.Repositories.Interfaces;
using NilexTicket.Util;

namespace NilexTicket.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepositoty userRepositoty;
        private ITicketRepository ticketRepository;
        public HomeController()
        {
            userRepositoty = new NHUserRepository();
            ticketRepository = new NHTicketRepository();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User veri)
        {
            if (veri == null)
            {
                return Json(false);
            }

            if (veri.Username == "" || string.IsNullOrEmpty(veri.Username))
            {
                return Json(false);
            }

            if (veri.Password == "" || string.IsNullOrEmpty(veri.Password))
            {
                return Json(false);
            }

            User kisi = userRepositoty.GetUserByLogin(veri.Username);
             
            if (kisi == null)
            {
                return Json(false);
            }
            else
            {

                var de = DESEncrypt.Decrypt(kisi.Password);

                if (de != veri.Password)
                {
                    return Json(false);
                }

                if (kisi.Role == "Admin")
                {
                    Session["Admin"] = kisi.Username;
                    return Json("Admin");
                }
                else
                {
                    Session["User"] = kisi.Username;
                    return Json("User");
                }
            }
        }
        public void UserDegisti(string kadi)
        {
            Session["User"] = kadi;
        }
        public void Logout()
        {
            Session.Abandon();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(User data)
        {
            try
            {
                if (data == null)
                {
                    return Json(false);
                }

                if (data.FullName == "" || string.IsNullOrEmpty(data.FullName))
                {
                    return Json(false);
                }

                if (data.Username == "" || string.IsNullOrEmpty(data.Username))
                {
                    return Json(false);
                }

                if (data.Mail == "" || string.IsNullOrEmpty(data.Mail))
                {
                    return Json(false);
                }

                if (data.Password == "" || string.IsNullOrEmpty(data.Password))
                {
                    return Json(false);
                }

                User checkExistUser = userRepositoty.GetUserByLogin(data.Username);

                if (checkExistUser != null)
                {
                    if (checkExistUser.ID > 0)
                    {
                        return Json(false);
                    }
                }
                else
                {
                    User newticket = new User();
                    newticket.FullName = data.FullName;
                    newticket.Username = data.Username;
                    newticket.Mail = data.Mail;
                    newticket.Password = DESEncrypt.Encrypt(data.Password);
                    newticket.Role = "User";
                    userRepositoty.Save(newticket);
                    return Json(true);
                }
            }
            catch (Exception)
            {
            }

            return Json(false);
        }
    }
}
