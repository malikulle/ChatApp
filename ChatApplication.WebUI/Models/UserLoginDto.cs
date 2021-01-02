using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.WebUI.Models
{
    public class UserLoginDto
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email Boş Olamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola Boş Olamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
