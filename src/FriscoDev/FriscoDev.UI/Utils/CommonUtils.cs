using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace FriscoDev.UI.Utils
{
    public class CommonUtils
    {

        public static List<decimal> SplitStringToDecimal(string location)
        {
            List<decimal> _list = new List<decimal>();
            try
            {
                _list.Add(Convert.ToDecimal(location.Split(',')[0]));
                _list.Add(Convert.ToDecimal(location.Split(',')[1]));
            }
            catch (Exception ex)
            {
                _list.Add(0);
                _list.Add(0);
            }
            return _list;

        }

        public static string ConvertShowDate(DateTime dt)
        {
            if (dt == null || dt == DateTime.MinValue || dt == DateTime.MaxValue)
            {
                return GetLocalTime().AddYears(-1).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        public static DateTime GetLocalTime(string TimeZoneId = "Pacific Standard Time")
        {
            try
            {
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId));
            }
            catch (Exception ex)
            {
                return DateTime.UtcNow;
            }

        }

        public static DateTime GetLocalTime(DateTime curDate, string TimeZoneId = "Pacific Standard Time")
        {
            try
            {
                return TimeZoneInfo.ConvertTimeFromUtc(curDate, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId));
            }
            catch (Exception ex)
            {
                return DateTime.UtcNow;
            }

        }

        public static string ConvertDirection(string strDirection, int type = 0)
        {
            string result = string.Empty;
            switch (strDirection)
            {
                default:
                case "":
                case "none":
                case "0":
                    result = "North";
                    break;
                case "45":
                    result = "North East";
                    break;
                case "90":
                    result = "East";
                    break;
                case "135":
                    result = "South East";
                    break;
                case "180":
                    result = "South";
                    break;
                case "225":
                    result = "South West";
                    break;
                case "270":
                    result = "West";
                    break;
                case "315":
                    result = "North West";
                    break;
            }
            if (type == 1)
                result = result.Replace(" ", string.Empty);
            return result.Trim();
        }

        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }

        public static T DeserializeJsonToObject<T>(string json)
            where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            var result = o as T;
            return result;
        }

        public static TimerFunctionTypeEnum GetTimerFunctionTypeEnumName(int curVal)
        {
            TimerFunctionTypeEnum _type = new TimerFunctionTypeEnum();
            switch (curVal)
            {
                case 0:
                    _type = TimerFunctionTypeEnum.SpeedDisplay;
                    break;
                case 1:
                    _type = TimerFunctionTypeEnum.SpeedLimit;
                    break;
                case 2:
                    _type = TimerFunctionTypeEnum.TrafficStatistics;
                    break;
                case 3:
                    _type = TimerFunctionTypeEnum.Message1;
                    break;
                case 4:
                    _type = TimerFunctionTypeEnum.Message2;
                    break;
                case 5:
                    _type = TimerFunctionTypeEnum.Message3;
                    break;
                default:
                    _type = TimerFunctionTypeEnum.SpeedDisplay;
                    break;
            }
            return _type;
        }

        public static TimerModeEnum GetTimerModeEnumName(int curVal)
        {
            TimerModeEnum _type = new TimerModeEnum();
            switch (curVal)
            {
                case 0:
                    _type = TimerModeEnum.Off;
                    break;
                case 1:
                    _type = TimerModeEnum.Period;
                    break;
                case 2:
                    _type = TimerModeEnum.Daily;
                    break;
                case 3:
                    _type = TimerModeEnum.SelectedDays;
                    break;
                case 4:
                    _type = TimerModeEnum.AlwaysOn;
                    break;
                default:
                    _type = TimerModeEnum.Off;
                    break;
            }
            return _type;
        }

        public static TimerCalendarControlEnum GetTimerCalendarControlEnumName(int curVal)
        {
            TimerCalendarControlEnum _type = new TimerCalendarControlEnum();
            switch (curVal)
            {
                case 0:
                    _type = TimerCalendarControlEnum.Off;
                    break;
                case 1:
                    _type = TimerCalendarControlEnum.On;
                    break;
                default:
                    _type = TimerCalendarControlEnum.Off;
                    break;
            }
            return _type;
        }

        public static bool CheckDateIsWorkend(DateTime dtime)
        {
            bool bl = false;
            string str = Convert.ToString(dtime.DayOfWeek);
            if (str == "Sunday" || str == "Saturday")
            {
                bl = true;
            }
            return bl;
        }

        public static int GetCurPmdId()
        {
            int tempint = 0;
            if (System.Web.HttpContext.Current.Session["curpmdid"] != null)
            {
                tempint = Convert.ToInt32(System.Web.HttpContext.Current.Session["curpmdid"]);
            }
            return tempint;
        }

        public static string GetNCiString(int num = 0)
        {
            string str = "";
            String strtemp = Convert.ToString(num, 2);
            int index = strtemp.Length - 1;
            foreach (char ch in strtemp)
            {
                if (ch == '1')
                {
                    int sint = Convert.ToInt32(Math.Pow(2, index));
                    if (str == "")
                    {
                        str = GetDaysName(sint);
                    }
                    else
                    {
                        str = str + "," + GetDaysName(sint);
                    }
                }
                index--;
            }
            return str;
        }

        public static string GetDaysName(int num)
        {
            string strtemp = "";
            if (num == 128)
            {
                strtemp = "Sun";
            }
            else if (num == 64)
            {
                strtemp = "Mon";
            }
            else if (num == 32)
            {
                strtemp = "Tue";
            }
            else if (num == 16)
            {
                strtemp = "Wed";
            }
            else if (num == 8)
            {
                strtemp = "Thu";
            }
            else if (num == 4)
            {
                strtemp = "Fri";
            }
            else if (num == 2)
            {
                strtemp = "Sat";
            }
            else
            {
                strtemp = "";
            }
            return strtemp;
        }

        public static int GetNCiNum(string days = "")
        {
            int cint = 0;
            string[] _arr = days.Split(',');
            foreach (string ch in _arr)
            {
                if (!string.IsNullOrEmpty(ch))
                {
                    cint = cint + GetDaysNum(ch);
                }
            }
            return cint;
        }

        public static int GetDaysNum(string _dayName)
        {
            int cint = 0;
            if (_dayName == "Sun")
            {
                cint = 128;
            }
            else if (_dayName == "Mon")
            {
                cint = 64;
            }
            else if (_dayName == "Tue")
            {
                cint = 32;
            }
            else if (_dayName == "Wed")
            {
                cint = 16;
            }
            else if (_dayName == "Thu")
            {
                cint = 8;
            }
            else if (_dayName == "Fri")
            {
                cint = 4;
            }
            else if (_dayName == "Sat")
            {
                cint = 2;
            }
            else
            {
                cint = 0;
            }
            return cint;
        }

        public static string GetStringValue(byte[] value, int maxchars, Boolean removeTrailingSpace)
        {
            if (value == null)
            {
                return string.Empty;
            }
            int len = value.Length;
            if (maxchars != 0)
            {
                if (value.Length > maxchars)
                {
                    len = maxchars;
                }
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] < 0x20 || value[i] > 127)
                {
                    value[i] = 0x20;
                }
            }
            string s = Encoding.UTF8.GetString(value, 0, len);
            if (removeTrailingSpace)
            {
                s = s.TrimEnd();
            }
            return s;
        }

        public static int GetLast7Digits(string id)
        {
            int len = id.Length;

            if (len > 7)
                id = id.Remove(0, len - 7);

            int value = Convert.ToInt32(id);

            return value;
        }

        public static string SendPostHttpRequest(string url, string contentType, string requestData)
        {
            WebRequest request = (WebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            byte[] postBytes = null;
            request.ContentType = contentType;
            postBytes = Encoding.UTF8.GetBytes(requestData);
            request.ContentLength = postBytes.Length;
            using (Stream outstream = request.GetRequestStream())
            {
                outstream.Write(postBytes, 0, postBytes.Length);
            }
            string result = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                if (response != null)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }

                }
            }
            return result;
        }

        public static string SendGetHttpRequest(string url, string contentType = "application/x-www-form-urlencoded")
        {
            string result = "";
            try
            {
                WebRequest request = (WebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = contentType;
                using (WebResponse response = request.GetResponse())
                {
                    if (response != null)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = "";
            }
            return result;
        }

        public static string SaveUploadPicture(HttpPostedFileBase file)
        {
            try
            {
                string type = file.ContentType;
                if (type.IndexOf("jpeg") > -1 || type.IndexOf("gif") > -1 || type.IndexOf("png") > -1)
                {
                    string folder = "/Upload/Images";
                    return SaveUploadFile(file, folder, null);
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string SaveUploadFile(HttpPostedFileBase file, string folder, string httpurl)
        {
            if (file == null || file.ContentLength == 0)
            {
                return "";
            }
            var serverPath = AppDomain.CurrentDomain.BaseDirectory + folder;

            string localPath = Path.Combine(serverPath, file.FileName);
            string dire = Path.GetDirectoryName(localPath);
            if (!Directory.Exists(dire + "\\"))
            {
                Directory.CreateDirectory(dire + "\\");
            }

            string filename = Path.GetFileName(file.FileName);//文件名
            string newname = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            file.SaveAs(dire + "\\" + newname);
            return folder + "/" + newname;
        }

        #region 根据年月日计算星期
        /// <summary>
        /// 根据年月日计算星期几(Label2.Text=CaculateWeekDay(2004,12,9);)
        /// </summary>
        /// <param name="y">年</param>
        /// <param name="m">月</param>
        /// <param name="d">日</param>
        /// <returns></returns>
        public static string CaculateWeekDay(int y, int m, int d)
        {
            if (m == 1) m = 13;
            if (m == 2) m = 14;
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;
            string weekstr = "";
            switch (week)
            {
                case 1: weekstr = "Monday"; break;
                case 2: weekstr = "Tuesday"; break;
                case 3: weekstr = "Wednesday"; break;
                case 4: weekstr = "Thursday"; break;
                case 5: weekstr = "Friday"; break;
                case 6: weekstr = "Saturday"; break;
                case 7: weekstr = "Sunday"; break;
            }
            return weekstr;
        }

        public static string GetConvertWeekday(int item)
        {
            string result = string.Empty;
            switch (item)
            {
                default:
                case 1:
                    result = "Sunday";
                    break;
                case 2:
                    result = "Monday";
                    break;
                case 3:
                    result = "Tuesday";

                    break;
                case 4:
                    result = "Wednesday";
                    break;
                case 5:
                    result = "Thursday";

                    break;
                case 6:
                    result = "Friday";
                    break;
                case 7:
                    result = "Saturday";
                    break;
            }
            return result;
        }
        #endregion

        #region 转换datetime类型
        /// <summary>
        /// 转换datetime类型
        /// </summary>
        /// <param name="data"></param>
        /// <param name="RtnData"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object data, DateTime RtnData)
        {
            DateTime rtnData = RtnData;
            try
            {
                if (data != null && data.ToString().Length > 0 && Convert.ToDateTime(data).ToString("yyyy") != "1900")
                    rtnData = Convert.ToDateTime(data);
            }
            catch
            {
            }
            return rtnData;
        }
        #endregion

        public static string GetDeviceState(string pId, int pmdId)
        {
            /*
            string stateName = "";

            bool bl1 = false;
            var pmdService = new PmdService();
            Pmd pmdModel = pmdService.GetPmd(pId);
            if (pmdModel != null)
            {
                bl1 = pmdModel.Connection;
            }

            var messageService = new MessageService();
            bool bl2 = messageService.CheckDeviceHasMsg(pmdId);

            if (bl1)
            {
                if (bl2)
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
                //offline red 
                stateName = "red";
            }

            return stateName;
            */
            return string.Empty;
        }

        public static string ConvertStrShowDate(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "---";

            return Convert.ToDateTime(str).ToString("MM-dd-yyyy HH:mm");

        }
    }

    public enum TimerModeEnum
    {
        Off = 0,
        Period = 1,
        Daily = 2,
        SelectedDays = 3,
        AlwaysOn = 4,
    };

    public enum TimerFunctionTypeEnum
    {
        SpeedDisplay = 0,
        SpeedLimit = 1,
        TrafficStatistics = 2,
        Message1 = 3,
        Message2 = 4,
        Message3 = 5
    };


    public enum TimerCalendarControlEnum
    {
        Off = 0,
        On = 1,
    };

    public enum DirectionEnum
    {
        Off = 0,
        On = 1,
    };
}