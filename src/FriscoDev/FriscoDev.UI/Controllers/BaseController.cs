using FriscoDev.Application.ViewModels;
using FriscoDev.UI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FriscoDev.UI.Helper;
using FriscoDev.Code.Helper;

namespace FriscoDev.UI.Controllers
{
    public class BaseController : Controller
    {
      
        public BaseController()
        {
            string redirectUrl = GetRedirectUrl();

            if (!LoginHelper.IsOnline())
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.Redirect(redirectUrl);
                System.Web.HttpContext.Current.Response.End();
            }

        }

        public string GetRedirectUrl()
        {
            string redirectUrl = string.Format("{0}/Login/Index?p={1}", 
                HttpUtils.WebDomainPath(),System.Web.HttpUtility.UrlEncode
                (System.Web.HttpContext.Current.Request.Url.AbsoluteUri));
            return redirectUrl;
        }

        public PMGModel BaseSelectedPMG()
        {
            PMGModel model = new PMGModel();
            if (System.Web.HttpContext.Current.Session["SelectPMG"] != null)
            {
                model = System.Web.HttpContext.Current.Session["SelectPMG"] as PMGModel;
            }
            return model;
        }



    }
}