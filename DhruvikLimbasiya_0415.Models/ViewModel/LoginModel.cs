using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhruvikLimbasiya_0415.Models.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        public string password { get; set; }

        public string Token { get; set; }
    }
}
