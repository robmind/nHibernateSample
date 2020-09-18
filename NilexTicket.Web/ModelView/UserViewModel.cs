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
        [Required(ErrorMessage = "User adınızı girmediniz")]
        [StringLength(100, ErrorMessage = "User adınız 100 karakterden fazla olamaz")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Adınızı girmediniz")]
        [StringLength(30, ErrorMessage = "Adınız 30 karakterden fazla olamaz")]
        [Display(Name = "Fullname")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Şifrenizi girmediniz")]
        [StringLength(20, ErrorMessage = "Şifreniz 20 karakterden fazla olamaz")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email'inizi girmediniz")]
        [StringLength(100, ErrorMessage = "Email'iniz 100 karakterden fazla olamaz")]
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