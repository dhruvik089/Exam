using DhruvikLimbasiya_0415.Api.JwtService;
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
using System.Web;
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


        [HttpPost]
        [Route("api/LoginRegister/Login")]
        public LoginModel Login(LoginModel user)
        {
            string email = user.email;
            string password = user.password;
            var keepLogin = true;
            bool keepLoginSession;

            keepLoginSession = keepLogin == true;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Please enter valid username and password");

                return null;
            }

            Registration appUserInfo = _context.Registration.FirstOrDefault(u => u.email == email);

            if (appUserInfo != null && ModelState.IsValid && appUserInfo.email == user.email && appUserInfo.password == user.password)
            {
                string encryptedPwd = password;

                var userPassword = appUserInfo.password;
                var username = appUserInfo.email;
                if (encryptedPwd.Equals(userPassword) && username.Equals(email))
                {
                    var role = appUserInfo.name;
                    var jwtToken = Authentication.GenerateJWTAuthetication(email, role);
                    var validUserName = Authentication.ValidateToken(jwtToken);

                    if (string.IsNullOrEmpty(validUserName))
                    {
                        ModelState.AddModelError("", "Unauthorized login attempt ");

                        return null;
                    }

                    var cookie = new HttpCookie("jwt", jwtToken)
                    {
                        HttpOnly = true,
                        Secure = true,
                        
                    };
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    user.Token = jwtToken;

                    return user;
                }
            }
            return user;
        }
    }
}