using DhruvikLimbasiya_0415.Common;
using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Models.ViewModel;
using DhruvikLimbasiya_0415.Services.Interface;
using DhruvikLimbasiya_0415.Services.Services;
using DhruvikLimbasiya_0415.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DhruvikLimbasiya_0415.Controllers
{

    public class LoginRegisterController : Controller
    {
        IRegistrationInterface _register;
        IWalletInterface _wallet;
        GameReward_0415Entities _context = new GameReward_0415Entities();
        public LoginRegisterController()
        {
            _register = new RegistrationServices();
            _wallet = new WalletServices();
        }

        public ActionResult Login()
        {
            SessionHelper.Logout();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel _loginModel)
        {

            var registration = _context.Registration.FirstOrDefault(m => m.email == _loginModel.email);
            if(registration!=null)
            {
                if (ModelState.IsValid && registration.password == _loginModel.password && registration.email == _loginModel.email && !SessionHelper.isLogin())
                {
                    @Session["UserName"] = registration.name;
                    SessionHelper.UserName = registration.name;
                    SessionHelper.email = _loginModel.email;
                    SessionHelper.UserId = registration.user_id;
                    @Session["UserId"] = registration.user_id;
                    Session["TotalWalletAmount"] = _wallet.totalWalletAmount(registration.user_id);
                    TempData["Login"] = "Login SuccessFuly..!!";
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    TempData["LoginFailed"] = "Login Failed..!!";
                    ModelState.AddModelError("password", "Email or Password wrong Please try again");
                    return View();
                }
            }
            else
            {
                TempData["LoginFailed"] = "Login Failed..!!";
                ModelState.AddModelError("password", "Email or Password wrong Please try again");
                return View();
            }

        }


        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationModel registrationModel)
        {
            var IsEmailExist = _context.Registration.Any(m => m.email == registrationModel.email);
            if (ModelState.IsValid && !IsEmailExist)
            {
                await WebHelper.AddUser(registrationModel, "Register");
                var userList = _context.Registration.Where(m => m.email == registrationModel.email).FirstOrDefault();

                SessionHelper.UserId = userList.user_id;
                _wallet.addWaletData(SessionHelper.UserId);

                TempData["register"] = "Success  Fully Register..!!";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["registerFail"] = "Failed Register..!!";
                ModelState.AddModelError("Email", "Email Aready Exist");
                return View();
            }
        }

        public ActionResult Logout()
        {
            SessionHelper.Logout();
            return RedirectToAction("Login");
        }

        public int TotalWalletAmount(int id)
        {
            return _wallet.totalWalletAmount(id);
        }

    }
}