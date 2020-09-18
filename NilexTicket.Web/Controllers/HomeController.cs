using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NilexTicket.DB;
using NilexTicket.DB.Repositories;
using NilexTicket.DB.Repositories.Interfaces;

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
            User kisi = userRepositoty.LoadAllUser().SingleOrDefault(x => x.Username == veri.Username & x.Password == veri.Password);
            if (kisi == null)
                return Json(false);
            else
            {
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
                User newticket = new User();
                newticket.FullName = data.FullName;
                newticket.Username = data.Username;
                newticket.Mail = data.Mail;
                newticket.Password = data.Password;
                newticket.Birthdate = data.Birthdate;
                newticket.Role = "User";
                userRepositoty.Save(newticket);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public ActionResult UserKontrolEt(string Username)
        {
            User user = userRepositoty.GetAll().Where(u => u.Username == Username).FirstOrDefault();
            if (user != null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public ActionResult EmailKontrolEt(string gelenMail)
        {
            User mail = userRepositoty.GetAll().SingleOrDefault(x => x.Mail == gelenMail);
            if (mail != null)
                return Json(true);
            else
                return Json(false);

        }
    }
}
