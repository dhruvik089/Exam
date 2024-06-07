using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhruvikLimbasiya_0415.Helper.Helper
{
    public class ConvertModelHelper
    {
        public static Registration ConvertModelToDbModel(RegistrationModel registrationModel)
        {
            Registration _register = new Registration();
            _register.name = registrationModel.name;
            _register.email = registrationModel.email;
            _register.password = registrationModel.password;

            return _register;
        }
    }
}
