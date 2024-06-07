using DhruvikLimbasiya_0415.Helper.Helper;
using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Models.ViewModel;
using DhruvikLimbasiya_0415.Services.Interface;
using DhruvikLimbasiya_0415.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DhruvikLimbasiya_0415.Api.Controllers
{
    public class LoginRegisterController : ApiController
    {
        readonly IRegistrationInterface _register;

        GameReward_0415Entities _context = new GameReward_0415Entities();

        public LoginRegisterController()
        {
            _register = new RegistrationServices();
        }

        [HttpPost]
        [Route("api/LoginRegister/Register")]
        public Registration Register(RegistrationModel _registrationModel)
        {
            Registration _registerUser = new Registration();
            _registerUser = ConvertModelHelper.ConvertModelToDbModel(_registrationModel);
            var isEmailExist = _context.Registration.Any(x => x.email == _registrationModel.email);

            if (!isEmailExist)
            {
                _context.Registration.Add(_registerUser);
                _context.SaveChanges();
                return _registerUser;
            }
            else
            {
                return null;
            }
        }
    }
}