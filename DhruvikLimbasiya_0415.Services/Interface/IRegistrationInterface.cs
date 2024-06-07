using DhruvikLimbasiya_0415.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhruvikLimbasiya_0415.Services.Interface
{
    public interface IRegistrationInterface
    {
        bool AddUser(RegistrationModel _registrationModel);
    }
}
