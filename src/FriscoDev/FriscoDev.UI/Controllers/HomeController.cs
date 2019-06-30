using AutoMapper;
using FriscoDev.Application.Models;
using FriscoDev.UI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FriscoDev.Application.EngrDevNew;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.UI.ViewModel;
using FriscoDev.Code.Helper;
namespace FriscoDev.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly PMDApp _pMDApp = new PMDApp();
        private readonly MessageApp _messageApp = new MessageApp();
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }

        #region map
        [HttpPost]
        public JsonResult MapDevices()
        {
            var list = _pMDApp.GetPMDEntities(string.Empty, 0);
            if (list.Count == 0)
                return Json(new { code = 10 });
            var viewList = new
            {
                ZoomLevel = 13,
                Positions = list.Select(d => new { address = ForAddress(d.Address), name = d.PMDName, imsi = d.IMSI, x = CommonUtils.SplitStringToDecimal(d.Location)[0], y = CommonUtils.SplitStringToDecimal(d.Location)[1], t = d.DeviceType, s = GetDeviceIcon(d.IMSI, d.PMD_ID.ToInt(0)), direction = GetDirection(d.Address) })
            };
            return Json(new { code = 0, data = viewList });
        }

        public static string GetDirection(string address)
        {
            var model = ForAddressModel(address);
            if (model != null)
                return CommonUtils.ConvertDirection(model.Direction);
            else
                return "None";
        }

        public string GetDeviceIcon(string IMSI, int PMD_ID)
        {
            string stateName = "red";
            bool bo1 = false;
            var model = _pMDApp.GetPMGModel(IMSI);
            if (model != null)
            {
                bo1 = model.Connection.ObjToBool();
            }
            bool bo2 = this._messageApp.CheckDeviceHasMsg(PMD_ID);
            if (bo1)
            {
                if (bo2)
                {
                    stateName = "yellow";
                }
                else
                {
                    stateName = "green";
                }
            }
            else
            {
                stateName = "red";
            }
            return stateName;
        }

        public static string ForAddress(string result)
        {
            AddressViewModel pmd = new AddressViewModel();
            if (string.IsNullOrEmpty(result))
                return "";
            var arrAddress = result.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            if (arrAddress.Length > 0)
            {
                pmd.Address = arrAddress[0].Replace("Address:", string.Empty);
                return pmd.Address;
            }
            return "";
        }

        public static AddressViewModel ForAddressModel(string result)
        {
            AddressViewModel pmd = new AddressViewModel();
            if (string.IsNullOrEmpty(result))
                return pmd;

            var arrAddress = result.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            if (arrAddress.Length > 1)
            {
                pmd.Address = arrAddress[0].Replace("Address:", string.Empty);
                pmd.Direction = arrAddress[1].Replace("Direction:", string.Empty);
            }
            return pmd;
        }
        #endregion


        [HttpPost]
        public JsonResult GetPMGDeviceList()
        {
            DataEnitity<PMDEntity> result = new DataEnitity<PMDEntity>();
            List<PMDEntity> list = this._pMDApp.GetPMDEntities(string.Empty, 0);
            if (list.Count == 0)
            {
                result.code = 10;
                result.msg = "no data";
                return Json(result);
            }
            result.code = 0;
            result.data = list;
            return Json(result);
        }

        [HttpPost]
        public JsonResult SetSelectedPMGDev(string imsi)
        {
            ModelEnitity<PMDEntity> result = new ModelEnitity<PMDEntity>();
            PMDEntity model = this._pMDApp.GetPMGModel(imsi);
            if (model == null)
            {
                System.Web.HttpContext.Current.Session["SelectPMG"] = null;
                result.code = 10;
                return Json(result);
            }
            System.Web.HttpContext.Current.Session["SelectPMG"] = model;
            result.code = 0;
            result.model = model;
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSelectedPMGDev()
        {
            ModelEnitity<PMDEntity> result = new ModelEnitity<PMDEntity>();

            if (System.Web.HttpContext.Current.Session["SelectPMG"] == null)
            {
                result.code = 10;
                return Json(result);
            }
            else
            {
                result.model = System.Web.HttpContext.Current.Session["SelectPMG"] as PMDEntity;
                result.code = 0;
                return Json(result);
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }



    }
}