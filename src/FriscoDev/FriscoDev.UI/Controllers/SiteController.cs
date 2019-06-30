using FriscoDev.Application.EngrDevNew;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.UI.Helper;
using FriscoDev.UI.Utils;
using FriscoDev.UI.ViewModel;
using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FriscoDev.UI.Controllers
{
    public class SiteController : BaseController
    {
        public ActionResult Index()
        {
            var userTypeId = LoginHelper.UserType;
            var userId = LoginHelper.UserID;
            ViewBag.UserType = userTypeId;
            var userService = new AccountApp();

            var model = GetLogoInfo(userTypeId, userId.ToString());
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
                userId = userService.GetParentIDByUser(UR_ID);
            }
            else
            {//管理员
                userId = UR_ID;
            }

            SiteConfigEntity site = null;
            var sitConfigApp = new SiteConfigApp();
            site = sitConfigApp.GetSiteConfigByUser(userId);

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

                var userId = LoginHelper.UserID;

                configEntity.Login_UR_ID = userId;
                var sitconfigApp = new SiteConfigApp();
                int i = sitconfigApp.GetIsExistSiteConfigByUser(configEntity.Login_UR_ID);

                configEntity.Address = GetJsonString(siteConfigViewModel);
                if (i > 0)
                {
                    sitconfigApp.SaveSiteConfig(configEntity);
                }
                else
                {
                    sitconfigApp.AddSiteConfig(configEntity);
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