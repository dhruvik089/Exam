using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhruvikLimbasiya_0415.Models.ViewModel
{
    public class RegistrationModel
    {
        //public int user_id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "enter valid email")]
        [MaxLength(50, ErrorMessage = "Name maximum is 50 charecter")]
        [MinLength(2, ErrorMessage = "Name minimum is 2 charecter")]
        public string name { get; set; }

        [Required(ErrorMessage = "Enter email")]
        [RegularExpression(@"[A-Za-z0-9\._%+\-]+@[A-Za-z0-9\.\-]+\.[A-Za-z]{2,}", ErrorMessage = "enter valid email")]
        public string email { get; set; }
        [MinLength(8,ErrorMessage ="Password Must be 8 charecter")]
        [Required(ErrorMessage = "Enter password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Enter Confirm Password ")]
        
        [Compare("password",ErrorMessage ="Password doesn't match")]
        public string confirmPassword { get; set; }

    }
}
