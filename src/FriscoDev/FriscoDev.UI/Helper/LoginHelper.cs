using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.Code.Helper;

namespace FriscoDev.UI.Helper
{
    public class LoginHelper
    {
        public static string LoginCookieUID { get { return "Login_Cookies_UserId"; } }
        public static string LoginCookieUserName { get { return "Login_Cookies_UserName"; } }
        public static string LoginCookieRealName { get { return "Login_Cookies_RealName"; } }
        public static string LoginCookieUserType { get { return "Login_Cookies_UserType"; } }

        public static string UserID
        {
            get { return CookieHelper.GetCookie(LoginHelper.LoginCookieUID); }
        }
        public static string UserName
        {
            get { return CookieHelper.GetCookie(LoginHelper.LoginCookieUserName); }
        }

        public static string RealName
        {
            get { return CookieHelper.GetCookie(LoginHelper.LoginCookieRealName); }
        }

        public static int UserType
        {
            get { return CookieHelper.GetCookie(LoginHelper.LoginCookieUserType).ToInt(0); }
        }


        public static bool IsOnline()
        {
            if (!string.IsNullOrEmpty(LoginHelper.UserID) && !string.IsNullOrEmpty(LoginHelper.UserName))
                return true;
            return false;
        }


        public static void SetLoginCookie(AccountEntity user, int minute = 30)
        {
            string expireTimeSpan = minute.ToString("");
            CookieHelper.SetCookie(LoginHelper.LoginCookieUID, user.UR_ID, CookieHelper.TimeUtil.mi, expireTimeSpan);
            CookieHelper.SetCookie(LoginHelper.LoginCookieUserName, user.UR_NAME, CookieHelper.TimeUtil.mi, expireTimeSpan);
            CookieHelper.SetCookie(LoginHelper.LoginCookieRealName, user.UR_NAME, CookieHelper.TimeUtil.mi, expireTimeSpan);
            CookieHelper.SetCookie(LoginHelper.LoginCookieUserType, user.UR_TYPE_ID.ToString(), CookieHelper.TimeUtil.mi, expireTimeSpan);

        }

        public static void Logout()
        {

            CookieHelper.DelCookie(LoginHelper.LoginCookieUID);
            CookieHelper.DelCookie(LoginHelper.LoginCookieUserName);
            CookieHelper.DelCookie(LoginHelper.LoginCookieRealName);
            CookieHelper.DelCookie(LoginHelper.LoginCookieUserType);

            if (System.Web.HttpContext.Current.Session != null)
            {
                System.Web.HttpContext.Current.Session.Clear();
            }
        }


    }
}
