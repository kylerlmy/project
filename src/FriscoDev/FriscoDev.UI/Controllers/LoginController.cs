using FriscoDev.Application.Models;
using FriscoDev.Application.ViewModels;
using FriscoDev.UI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FriscoDev.Application.EngrDevNew;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.UI.Helper;
using FriscoDev.Code.Helper;


namespace FriscoDev.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly AccountApp _accountApp = new AccountApp();
        public LoginController()
        {

        }

        public ActionResult Index()
        {
            string sourceUrl = CommonHelper.GetPostValue("p");
            if (!string.IsNullOrEmpty(sourceUrl))
                sourceUrl = HttpUtility.UrlDecode(sourceUrl);

            ViewBag.SourceUrl = sourceUrl;
            return View();
        }

        [HttpPost]
        public JsonResult Verify(LoginCommand command)
        {
            if (string.IsNullOrEmpty(command.UserName) || string.IsNullOrEmpty(command.Password))
                return Json(new BaseEnitity { code = 300 });

            AccountEntity user = this._accountApp.GetAccountEntity(command.UserName, command.Password);
            if (user == null)
                return Json(new BaseEnitity { code = 500 });

            if (user.UR_ACTIVE == null || !user.UR_ACTIVE.ObjToBool())
                return Json(new BaseEnitity { code = 502 });

            LoginHelper.SetLoginCookie(user, 60 * 2);

            return Json(new BaseEnitity { code = 200 });

        }

        public ActionResult LoginOut()
        {
            LoginHelper.Logout();
            return RedirectToAction("Index", "Login");
        }

    }
}