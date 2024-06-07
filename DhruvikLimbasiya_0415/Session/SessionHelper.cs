using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DhruvikLimbasiya_0415.Session
{
    public class SessionHelper
    {
        public static int UserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["UserId"]);
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static string UserName
        {
            get
            {
                return HttpContext.Current.Session["UserName"] == null ? "" : Convert.ToString(HttpContext.Current.Session["UserName"]);
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
        public static string email
        {
            get
            {
                return HttpContext.Current.Session["email"] == null ? "" : Convert.ToString(HttpContext.Current.Session["email"]);
            }
            set
            {
                HttpContext.Current.Session["email"] = value;
            }
        }

        public static bool isLogin()
        {
            if (email == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
        }

    }
}