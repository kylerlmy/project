using System;
using System.Web.Mvc;
using FriscoDev.Application.EngrDevNew;
using FriscoDev.Code;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.UI.Utils;
using FriscoDev.UI.ViewModel;
using PMDCellularInterface;

namespace FriscoDev.UI.Controllers
{
    public class SetupController : BaseController
    {
        public AccountEntity loginUser;

        public ActionResult Index(decimal xvalue = 0, decimal yvalue = 0, string pid = "", int pmdid = 0)
        {
            if (pmdid > 0)
            {
                System.Web.HttpContext.Current.Session["curpmdid"] = xvalue + "," + yvalue + "," + pid + "," + pmdid;
            }

            ViewData["clockDate"] = CommonUtils.GetLocalTime(loginUser.TIME_ZONE).ToString("yyyy-MM-dd");
            ViewData["clockTime"] = CommonUtils.GetLocalTime(loginUser.TIME_ZONE).ToString("HH:mm");
            return View();
        }

        #region Get Setup Info
        public string GetDeviceSetupInfo(string pId = "")
        {
            bool result = false;

            PMDConfiguration configuration = null;

            var pmdService = new PMDApp();
            var pmdModel = pmdService.GetPMGModel(pId);
            if (pmdModel != null)
            {
                byte[] configurationData = null;
                if (pmdModel.NewConfiguration != null)
                {
                    configurationData = pmdModel.NewConfiguration;
                }
                else
                {
                    configurationData = pmdModel.CurrentConfiguration;
                }
                //byte[] configurationData = pmdModel.CurrentConfiguration;
                result = true;
                if (configurationData != null)
                {
                    configuration = new PMDConfiguration(configurationData);

                    if (configuration != null)
                    {
                        TimerSetting[] timerslist = new TimerSetting[5];
                        timerslist = configuration.pmdSetting.timers;
                        for (int i = 0; i < 5; i++)
                        {
                            int daynum = Convert.ToInt32(timerslist[i].days);
                            //daynum = 128 + 4 + 2;
                            configuration.pmdSetting.timers[i].daysName = CommonUtils.GetNCiString(daynum);
                        }
                    }
                }
                else
                {
                    configuration = new PMDConfiguration();
                }
            }

            var _result = new
            {
                Success = result,
                rows = configuration.pmdSetting
            };

            return _result.ToJson("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region Save Setup Info
        public string SaveDeviceSetupInfo(string pId, string timersObj, string gloalObj, string msgTopObj, string msgBottomObj)
        {
            bool result = false;

            PMDConfiguration configuration = null;

            var pmdService = new PMDApp();
            var pmdModel = pmdService.GetPMGModel(pId);
            if (pmdModel != null)
            {
                byte[] configurationData = pmdModel.CurrentConfiguration;
                if (configurationData != null)
                {
                    configuration = new PMDConfiguration(configurationData);

                    if (configuration != null)
                    {
                        result = true;
                    }

                    if (configuration != null)
                    {
                        //json
                        var timerList = CommonUtils.DeserializeJsonToList<Timers>(timersObj);
                        if (timerList != null)
                        {
                            int rowsindex = 0;
                            foreach (Timers tModel in timerList)
                            {
                                configuration.pmdSetting.timers[rowsindex].functionType = (PMDCellularInterface.TimerFunctionType)CommonUtils.GetTimerFunctionTypeEnumName(tModel.functionType);
                                configuration.pmdSetting.timers[rowsindex].modeType = (PMDCellularInterface.TimerMode)CommonUtils.GetTimerModeEnumName(tModel.modeType);
                                configuration.pmdSetting.timers[rowsindex].startDate = tModel.startDate;
                                configuration.pmdSetting.timers[rowsindex].startTime = tModel.startTime;
                                configuration.pmdSetting.timers[rowsindex].stopDate = tModel.stopDate;
                                configuration.pmdSetting.timers[rowsindex].stopTime = tModel.stopTime;

                                int cint = CommonUtils.GetNCiNum(tModel.daysName);
                                configuration.pmdSetting.timers[rowsindex].days = Convert.ToByte(cint);
                                configuration.pmdSetting.timers[rowsindex].speedLimit = tModel.speedLimit;
                                configuration.pmdSetting.timers[rowsindex].linkToCalendar = (PMDCellularInterface.TimerCalendarControl)CommonUtils.GetTimerCalendarControlEnumName(tModel.linkToCalendar);
                                rowsindex++;
                            }
                        }
                        bool userClock = false;
                        string clockDate = "";
                        string clockTime = "";

                        GlobalModel globalModel = CommonUtils.DeserializeJsonToObject<GlobalModel>(gloalObj);
                        if (globalModel != null)
                        {
                            configuration.pmdSetting.minSpeed = globalModel.minSpeed;
                            configuration.pmdSetting.maxSpeed = globalModel.maxSpeed;
                            configuration.pmdSetting.alertFlashType = globalModel.alertFlashType;
                            configuration.pmdSetting.alertMessageType = globalModel.alertMessageType;
                            configuration.pmdSetting.dataFormat = globalModel.dataFormat;

                            userClock = globalModel.userClock == 1 ? true : false;
                            clockDate = globalModel.clockDate;
                            clockTime = globalModel.clockTime;
                        }

                        //msgTopObj  ["!!!!!!"," ZONE\u0000"," DOWN\u0000"]
                        msgTopObj = msgTopObj.Replace("[", "");
                        msgTopObj = msgTopObj.Replace("]", "");
                        msgTopObj = msgTopObj.Replace("\"", "");
                        configuration.pmdSetting.topMsgs = msgTopObj.Split(',');
                        msgBottomObj = msgBottomObj.Replace("[", "");
                        msgBottomObj = msgBottomObj.Replace("]", "");
                        msgBottomObj = msgBottomObj.Replace("\"", "");
                        configuration.pmdSetting.bottomMsgs = msgBottomObj.Split(',');

                        byte[] newData = configuration.ToData();

                        if (newData != null)
                        {
                            var pmdNewModel = new PMDEntity();
                            pmdNewModel = pmdModel;
                            pmdNewModel.NewConfiguration = newData;
                            pmdNewModel.NewConfigurationTime = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";
                            //Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            //TODO: Need call UpdatePmd
                            // pmdService.UpdatePmd(pmdNewModel);
                            // Notify the change of configuration
                            PMDConfiguration.SendNotificationToCloudServer(PMDConfiguration.TableID.PMD, PMDConfiguration.DatabaseOperationType.ConfigurationUpdate, pmdModel.IMSI);
                            //PMDConfiguration.SendNotificationToCloudServer(PMDConfiguration.TableID.PMD, PMDConfiguration.DatabaseOperationType.ClockUpdate, pmdModel.IMSI);

                            DateTime nDate = new DateTime();
                            if (userClock)
                            {
                                nDate = CommonUtils.GetLocalTime(loginUser.TIME_ZONE);
                            }
                            else
                            {
                                nDate = Convert.ToDateTime(clockDate + " " + clockTime);
                            }
                            PMDConfiguration.UpdatePMDClock(pmdModel.IMSI, nDate);
                        }
                    }
                }
            }

            var _result = new
            {
                Success = result
            };

            return _result.ToJson("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

    }
}