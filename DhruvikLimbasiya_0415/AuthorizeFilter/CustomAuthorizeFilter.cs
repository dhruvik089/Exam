using DhruvikLimbasiya_0415.Api.JwtService;
using DhruvikLimbasiya_0415.Models.DbContext;
using DhruvikLimbasiya_0415.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace DhruvikLimbasiya_0415.AuthorizeFilter
{
    public class CustomAuthorizeFilter : AuthorizeAttribute
    {
        GameReward_0415Entities _context = new GameReward_0415Entities();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                Registration registration = _context.Registration.FirstOrDefault(m => m.name == SessionHelper.UserName);

                if (registration != null)
                {
                    return SessionHelper.isLogin();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!SessionHelper.isLogin())
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "LoginRegister" },
                    { "action", "Login" }
                });
            }
            else
            {
                filterContext.Result = new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            }
        }
    }      
}