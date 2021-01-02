using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.WebUI.Models
{
    public class UserRegisterDto
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email Boş Olamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Olamaz")]
        public string UserName { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola Boş Olamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Onay Parolanızı Giriniz")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
