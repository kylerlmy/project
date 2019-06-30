using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.UI.Helper;
using FriscoDev.UI.Utils;
using FriscoDev.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FriscoDev.UI.Controllers
{
    public class StatsLogController : Controller
    {
        private string _timeZone;

        public ActionResult Index(string xvalue = "0", string yvalue = "0", string pid = "", int pmdid = 0, string startDate = "", string endDate = "")
        {
            _timeZone = LoginHelper.LoginCookieTimeZone;
            if (pmdid > 0)
            {
                System.Web.HttpContext.Current.Session["curpmdid"] = xvalue + "," + yvalue + "," + pid + "," + pmdid;
            }
            if (string.IsNullOrEmpty(startDate))
            {
                ViewBag.StartDate = CommonUtils.GetLocalTime(_timeZone).AddHours(-1).ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                ViewBag.StartDate = CommonUtils.GetLocalTime(Convert.ToDateTime(startDate)).ToString("yyyy-MM-dd HH:mm");
            }
            if (string.IsNullOrEmpty(endDate))
            {
                ViewBag.EndDate = CommonUtils.GetLocalTime(_timeZone).ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                ViewBag.EndDate = CommonUtils.GetLocalTime(Convert.ToDateTime(endDate)).ToString("yyyy-MM-dd HH:mm");
            }

            return View();
        }

        /*
        //Real Time Chars
        public JsonNetResult DeviceCharts(int id, string startDate = "", string endDate = "")
        {
            _timeZone = LoginHelper.LoginCookieTimeZone;
            var statsLogService = new StatsLogService();
            if (!string.IsNullOrEmpty(startDate))
            {
                startDate = CommonUtils.GetLocalTime(Convert.ToDateTime(startDate)).ToString("yyyy-MM-dd HH:mm");
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                endDate = CommonUtils.GetLocalTime(Convert.ToDateTime(endDate)).ToString("yyyy-MM-dd HH:mm");
            }
            var statsLogs = statsLogService.GetStatsLogsToRealTimeCharts(id, startDate, endDate, _timeZone).OrderByDescending(x => x.Timestamp);

            DateTime dt1 = CommonUtils.GetLocalTime(Convert.ToDateTime(startDate));
            DateTime dt2 = CommonUtils.GetLocalTime(Convert.ToDateTime(endDate));

            TimeSpan ts = dt2.Subtract(dt1).Duration();
            int _day = ts.Hours;
            _day = _day > 0 ? _day : 1;

            if (statsLogs.Any())
            {
                var groupBySpeed = statsLogs.GroupBy(s => s.AverageSpeed);
                var chartData = new List<List<double>>();
                int _count = statsLogs.Count();
                var reportData = new HomeIndexViewModel.ReportData
                {
                    TotalCount = statsLogs.Count(),
                    Closing = statsLogs.Count(s => s.Direction == "CLOS"),
                    Away = statsLogs.Count(s => s.Direction == "AWAY"),
                    Average = Math.Round(statsLogs.Sum(s => s.AverageSpeed) / statsLogs.Count()),
                    Last = statsLogs.Min(s => s.LastSpeed),
                    HighAlam = statsLogs.Max(s => s.PeakSpeed),
                    LowAlam = statsLogs.Min(s => s.PeakSpeed),
                    AverageTotal = _count / _day,
                    LastDate = statsLogs.Max(s => s.Timestamp).ToString("yyyy-MM-dd HH:mm"),
                };

                foreach (var item in groupBySpeed)
                {
                    var list = new List<double> { item.Key };
                    var groupByDirection = item.GroupBy(x => x.Direction).ToDictionary(g => g.Key, g => g.ToList());


                    list.Add(groupByDirection.ContainsKey("CLOS") ? groupByDirection["CLOS"].Count : 0);
                    list.Add(groupByDirection.ContainsKey("AWAY") ? groupByDirection["AWAY"].Count : 0);
                    chartData.Add(list);
                }

                return new JsonNetResult
                {
                    Data = new
                    {
                        Success = true,
                        ViewData = new HomeIndexViewModel
                        {
                            ChartData = chartData,
                            Report = reportData
                        }
                    }
                };
            }

            return new JsonNetResult
            {
                Data = new { Success = false }
            };
        }

        */
    }
}