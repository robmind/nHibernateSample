using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NilexTicket.DB;

namespace NilexTicket.ModelView
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "You did not enter your user name")]
        [StringLength(100, ErrorMessage = "Your user name cannot exceed 100 characters.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You did not enter your name")]
        [StringLength(30, ErrorMessage = "Your name cannot exceed 30 characters.")]
        [Display(Name = "Fullname")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "You did not enter your password")]
        [StringLength(20, ErrorMessage = "Your password cannot exceed 20 characters.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You did not enter your email")]
        [StringLength(100, ErrorMessage = "Your email cannot exceed 100 characters.")]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        public int ID { get; set; }


        public static implicit operator UserViewModel(User usr2)
        {
            UserViewModel usr1 = new UserViewModel();
            usr1.ID = usr2.ID;
            usr1.FullName = usr2.FullName;
            usr1.Username = usr2.Username;
            usr1.Mail = usr2.Mail;
            usr1.Password = usr2.Password;
            return usr1;
        }
    }
}