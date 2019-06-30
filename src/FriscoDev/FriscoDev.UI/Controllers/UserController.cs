using AutoMapper;
using FriscoDev.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FriscoDev.UI.Controllers
{
    public class UserController : BaseController
    {
        public UserController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUserList(int pageIndex, int pageSize)
        {
            /*
            int iCount = 0;
            var list = this._userService.GetAccountList("", pageIndex, pageSize, out iCount);
            List<AccountViewModel> viewModel = Mapper.Map<List<AccountViewModel>>(list);
            #region page
            int pageCount = (int)Math.Ceiling(iCount / Convert.ToDouble(pageSize));
            if (pageCount > 0 && pageCount < pageIndex)
            {
                pageIndex = pageCount;
            }
            #endregion
            return Json(new { list = viewModel, pageCount= pageCount, iCount = iCount });
            */
            return null;
        }


    }
}