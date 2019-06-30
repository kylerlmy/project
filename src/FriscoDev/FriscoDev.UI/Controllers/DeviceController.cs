using Application.Common;
using AutoMapper;
using FriscoDev.Application.ViewModels;
using FriscoDev.UI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FriscoDev.Code;
using FriscoDev.Application.EngrDevNew;
namespace FriscoDev.UI.Controllers
{
    public class DeviceController : BaseController
    {
        private readonly PMDApp _pmdApp = new PMDApp();
        public DeviceController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDeviceList(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = _pmdApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpPost]
        public JsonResult GetDeviceList(int pageIndex, int pageSize)
        {
            /*
            int iCount = 0;
            var list = this._deviceService.GetDeviceList("", pageIndex, pageSize, out iCount);
            List<PMGModel> viewModel = Mapper.Map<List<PMGModel>>(list);
            #region page
            int pageCount = (int)Math.Ceiling(iCount / Convert.ToDouble(pageSize));
            if (pageCount > 0 && pageCount < pageIndex)
            {
                pageIndex = pageCount;
            }
            #endregion
            return Json(new { list = viewModel, pageCount = pageCount, iCount = iCount });
            */
            return null;
        }

        public ActionResult Message()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDeviceAlertMsg(string pmgId, string daylimit, int pageIndex, int pageSize)
        {
            /*
            string startDate = string.Empty;
            if (!string.IsNullOrEmpty(daylimit))
            {
                startDate = CommonUtils.GetLocalTime().AddDays(-daylimit.ToInt(0)).ToString("yyyy-MM-dd 00:00");
            }
            int iCount = 0;
            var list = this._deviceService.GetDeviceMessageList(pmgId, startDate, pageIndex, pageSize, out iCount);
            #region page
            int pageCount = (int)Math.Ceiling(iCount / Convert.ToDouble(pageSize));
            if (pageCount > 0 && pageCount < pageIndex)
            {
                pageIndex = pageCount;
            }
            #endregion
            return Json(new { list = list, pageCount = pageCount, iCount = iCount });
            */
            return null;

        }


        [HttpPost]
        public JsonResult DeleteAllWarning(string pmgId)
        {
            /*
            if (!string.IsNullOrEmpty(pmgId))
            {
                int PMGID = pmgId.ToInt(0);
                this._deviceService.DeleteWarningMessage(PMGID);
            }
            return Json(0);
            */
            return null;

        }

    }
}