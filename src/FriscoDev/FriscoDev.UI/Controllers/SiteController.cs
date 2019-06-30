using FriscoDev.Application.EngrDevNew;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.UI.Utils;
using FriscoDev.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FriscoDev.UI.Controllers
{
    public class SiteController : BaseController
    {
        private AccountEntity _loginUser;
        public ActionResult Index()
        {
            ViewBag.UserType = _loginUser.UR_TYPE_ID;
            var userService = new AccountApp();
            var model = GetLogoInfo(_loginUser.UR_TYPE_ID, _loginUser.UR_ID);
            if (model != null)
            {
                var site = GetSiteModel(model.Address);
                if (site != null)
                {
                    model.TimeZone = site.TimeZone;
                    model.Organization = site.Organization;
                    model.City = site.City;
                    model.State = site.State;
                    model.CountryName = site.CountryName;
                }
            }
            return View(model);
        }
        private SiteConfigViewModel GetLogoInfo(int UR_TYPE_ID, string UR_ID)
        {
            var result = new SiteConfigViewModel();
            string userId = string.Empty;
            var userService = new AccountApp();
            if (UR_TYPE_ID == 3)
            {
                //userId = userService.GetParentIDByUser(UR_ID);
            }
            else
            {//管理员
                userId = UR_ID;
            }

            SiteConfigEntity site = null;
            // site = userService.GetSiteConfigByUser(userId);

            result.Address = site.Address;
            var siteViewModel = GetSiteModel(site.Address);
            result.City = siteViewModel.City;
            result.CountryName = siteViewModel.CountryName;
            result.Default_Location = site.Default_Location;
            result.Id = site.Id;
            result.Login_UR_ID = site.Login_UR_ID;
            result.Organization = siteViewModel.Organization;
            result.ProfileImgUrl = site.ProfileImgUrl;
            result.SiteName = site.SiteName;
            result.State = siteViewModel.State;
            result.TimeZone = siteViewModel.TimeZone;
            return result;
        }

        [HttpPost]
        public ActionResult Save(SiteConfigViewModel siteConfigViewModel)
        {
            var result = new ResultEntity() { errorCode = 500, errorStr = "" };
            try
            {
                var configEntity = new SiteConfigEntity()
                {
                    Id = siteConfigViewModel.Id,
                    SiteName = siteConfigViewModel.SiteName,
                    Default_Location = siteConfigViewModel.Default_Location,
                    ProfileImgUrl = siteConfigViewModel.ProfileImgUrl
                };

                configEntity.Login_UR_ID = _loginUser.UR_ID;
                var userService = new AccountApp();
                int i = 0;//userService.GetIsExistSiteConfigByUser(site.Login_UR_ID);//TODO:need to call

                configEntity.Address = GetJsonString(siteConfigViewModel);
                if (i > 0)
                {
                    //TODO:Save
                    //  userService.SetSaveSiteConfig(site);
                }
                else
                {//TODO:Add
                    //userService.SetAddSiteConfig(site);
                }
                result.errorCode = 200;
            }
            catch (Exception e)
            {
                result.errorCode = 400;
                result.errorStr = e.Message;
            }
            return Json(result);

        }

        public static string GetJsonString(SiteConfigViewModel site)
        {
            var model = new SiteViewModel();
            if (site == null)
                return "";
            model.TimeZone = site.TimeZone;
            model.Organization = site.Organization;
            model.City = site.City;
            model.State = site.State;
            model.CountryName = site.CountryName;
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(model);
        }

        private SiteViewModel GetSiteModel(string address)
        {
            var model = new SiteViewModel();
            if (string.IsNullOrEmpty(address))
                return model;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<SiteViewModel>(address);
        }
    }
}