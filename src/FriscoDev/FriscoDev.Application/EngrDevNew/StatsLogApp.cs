using FriscoDev.Code;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.Domain.IRepository.EngrDevNew;
using FriscoDev.Domain.Model;
using FriscoDev.Repository.EngrDevNew;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace FriscoDev.Application.EngrDevNew
{
    public class StatsLogApp
    {
        private IStatsLogRepository _repository = new StatsLogRepository();

        public IEnumerable<StatsLogEntity> GetStatsLogsToDataLog(Pagination pagination,
            string startTime, string endTime, int pid, string timeZone)
        {
            DateTime _startTime = DateTime.Now.AddDays(-1);
            DateTime _endTime = DateTime.Now;
            DateTime.TryParse(startTime, out _startTime);
            DateTime.TryParse(endTime, out _endTime);
            var expression = ExtLinq.True<StatsLogEntity>();
            expression = expression.And(t => t.PMD_ID == pid);
            expression = expression.And(t => t.Timestamp >= _startTime);
            expression = expression.And(t => t.Timestamp <= _endTime);
            return _repository.FindList(expression, pagination);
        }
        public IEnumerable<StatsLogEntity> GetStatsLogsToDataLog_Bak(int pid, string timeZone)
        {
            var today = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
            var Start = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            var End = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
            var expression = ExtLinq.True<StatsLogEntity>();
            expression = expression.And(t => t.PMD_ID == pid);
            expression = expression.And(t => t.Timestamp >= Start);
            expression = expression.And(t => t.Timestamp <= End);
            return _repository.IQueryable(expression);
        }
        public IEnumerable<StatsLogEntity> GetStatsLogsToRealTimeCharts(int pid, string StartDate, string EndDate, string timeZone)
        {
            DateTime dStart = Convert.ToDateTime(StartDate);
            DateTime dEnd = Convert.ToDateTime(EndDate);
            var expression = ExtLinq.True<StatsLogEntity>();
            expression = expression.And(t => t.PMD_ID == pid);
            expression = expression.And(t => t.Timestamp >= dStart);
            expression = expression.And(t => t.Timestamp <= dEnd);
            return _repository.IQueryable(expression);
        }
        public IEnumerable<StatsLogEntity> GetStatsLogsToReport(int pid, string StartDate, string EndDate, string timeZone)
        {
            const string sql = @"with t as(
            select *, 
            SUBSTRING( CONVERT(varchar,[Timestamp],120),0,14)+':00' as StatDate,
            cast(datename(Minute, [Timestamp]) as int) Minss
             from StatsLog 
            where [PMD ID] = @Pid and [timestamp] between @Start and @End
             )
             select  [target id] as TargetId,[PMD ID] as PMDID, *,
             SUBSTRING( CONVERT(varchar,[Timestamp],120),0,14)+':'+(CASE WHEN  Minss >0 and Minss <15  THEN '00'
            WHEN Minss >=15 and Minss <30  THEN '15'
            WHEN Minss >=30 and Minss <45  THEN '30'
            ELSE '45' END) StatDate2 from t";
            DateTime dStart = Convert.ToDateTime(StartDate);
            DateTime dEnd = Convert.ToDateTime(EndDate);
            DbParameter[] parameter = 
              {
                  new SqlParameter("@Start",dStart),
                  new SqlParameter("@End",dEnd),
                  new SqlParameter("@Pid",pid)
              };
            return _repository.FindList(sql, parameter);
        }
        public IEnumerable<SpeedCount> GetSpeedCountFromStatsLogs(int pid, string StartDate, string EndDate, string timeZone, out double aveg)
        {
            DateTime dStart = Convert.ToDateTime(StartDate);
            DateTime dEnd = Convert.ToDateTime(EndDate);
            string sqlAvg = @" select SUM(AverageSpeed)/Count(0) as AvgSpeed from [StatsLog]";
            var AvgSpeed = _repository.DataDbContext.Database.SqlQuery<AverageSpeed>(sqlAvg).FirstOrDefault();
            aveg = AvgSpeed.AvgSpeed;
            string sql = @"WITH t AS 
                            (SELECT top 100 percent Direction,AverageSpeed,count(1)as iCount 
                            from StatsLog
                            where [PMD ID]=@Pid and [timestamp] between @Start and @End
                            group by Direction,AverageSpeed
                            order by AverageSpeed) 
                            SELECT AverageSpeed,ISNULL(AWAY,0) as AwayCount,ISNULL(CLOS,0) as ClosCount 
                            FROM t pivot( sum(iCount) FOR Direction IN (CLOS,AWAY)) m ";
            SqlParameter[] sqlParameters = { 
                    new SqlParameter { ParameterName = "Pid",Value = pid},
                    new SqlParameter{ParameterName = "Start",Value =dStart},
                    new SqlParameter{ParameterName="End",Value=dEnd}
             };
            return _repository.DataDbContext.Database.SqlQuery<SpeedCount>(sql, sqlParameters);
        }
        public IEnumerable<SurveyDataModel> GetSurveyDataList(int pid, string StartDate, string EndDate, string timeZone)
        {
            #region sql
            string sql = @" with t as (
                        select top 100 percent weekdate,Direction,min(subhour) as mintime,MAX(subhour) as maxtime from 
                        (
                        select *,Datepart(weekday,[timestamp]) as weekdate,convert(char(8),[timestamp],108) as subhour
                        from StatsLog where  [PMD ID]=@Pid and [timestamp] between @Start and @End
                        ) a
                        group by weekdate,Direction
                        order by weekdate)
                        SELECT t.weekdate as weeddate,
                         (SELECT mintime FROM t as a WHERE a.weekdate=t.weekdate AND a.Direction='AWAY ')AS 'aStartDate',
                        (SELECT maxtime FROM t as c WHERE c.weekdate=t.weekdate AND c.Direction='AWAY ')AS 'aEndDate',
                        (SELECT mintime FROM t as b WHERE b.weekdate=t.weekdate AND b.Direction='CLOS ')AS 'cStartDate',
                        (SELECT maxtime FROM t as d WHERE d.weekdate=t.weekdate AND d.Direction='CLOS ')AS 'cEndDate'
                        FROM t group by t.weekdate";
            #endregion

            DateTime dStart = Convert.ToDateTime(StartDate);
            DateTime dEnd = Convert.ToDateTime(EndDate);
            SqlParameter[] sqlParameters = { 
                    new SqlParameter { ParameterName = "Pid",Value = pid},
                    new SqlParameter{ParameterName = "Start",Value =dStart},
                    new SqlParameter{ParameterName="End",Value=dEnd}
             };
            return _repository.DataDbContext.Database.SqlQuery<SurveyDataModel>(sql, sqlParameters);
        }

        public IEnumerable<SpeedPercentileModel> GetWeeklyCountTimeList(int pid, string StartDate, string EndDate, string timeZone)
        {
            string sql = @"with t as (
                        select top 100 percent *,
                        (CASE WHEN subhour>'00:00:00' and subhour<='02:30:00' then '02:30:00'
                         WHEN subhour>'02:30:00' and subhour<='05:00:00' then '05:00:00'
                         WHEN subhour>'05:00:00' and subhour<='07:30:00' then '07:30:00'
                         WHEN subhour>'07:30:00' and subhour<='10:00:00' then '10:00:00'
                         WHEN subhour>'10:00:00' and subhour<='12:30:00' then '12:30:00'
                         WHEN subhour>'12:30:00' and subhour<='15:00:00' then '15:00:00'
                         WHEN subhour>'15:00:00' and subhour<='17:30:00' then '17:30:00'
                         WHEN subhour>'17:30:00' and subhour<='20:00:00' then '20:00:00'
                         WHEN subhour>'20:00:00' and subhour<='22:30:00' then '22:30:00'
                         ELSE '00:00:00' END ) as TimeSplit
                         from 
                        (select *,Datepart(weekday,[timestamp]) as weekdate,convert(char(8),[timestamp],108) as subhour
                        from StatsLog
                        where [PMD ID]=@Pid and [timestamp] between @Start and @End
                        ) s)
                        select TimeSplit,ISNULL([1],0) as 'SundayCount',ISNULL([2],0) as 'MondayCount',ISNULL([3],0) as 'TuesdayCount',
                        ISNULL([4],0) as 'WednesdayCount',ISNULL([5],0) as 'ThursdayCount',ISNULL([6],0) as 'FridayCount',ISNULL([7],0) as 'SaturdayCount'
                         from  (select top 100 percent TimeSplit,weekdate,Count(0) as iCount from t
                        group by TimeSplit,weekdate ) m
                        pivot( sum(iCount) FOR weekdate IN ([1],[2],[3],[4],[5],[6],[7])) k  order by TimeSplit
                         ";

            DateTime dStart = Convert.ToDateTime(StartDate);
            DateTime dEnd = Convert.ToDateTime(EndDate);
            SqlParameter[] sqlParameters = { 
                    new SqlParameter { ParameterName = "Pid",Value = pid},
                    new SqlParameter{ParameterName = "Start",Value =dStart},
                    new SqlParameter{ParameterName="End",Value=dEnd}
             };
            return _repository.DataDbContext.Database.SqlQuery<SpeedPercentileModel>(sql, sqlParameters);
        }

        public IEnumerable<CountPercentileModel> GetSpeedPercentileList(int pid, string StartDate, string EndDate, string timeZone)
        {
            string sql = @" SELECT AverageSpeed,isnull(Count(0),0) as iCount
                            from StatsLog
                            where  [PMD ID] = @Pid and[timestamp] between @Start and @End
                            -- where  [PMD ID] = 404685 and[timestamp] between '2017-2-19 00:00' and '2017-2-26 23:59'
                            group by AverageSpeed
                            order by AverageSpeed  ";

            DateTime dStart = Convert.ToDateTime(StartDate);
            DateTime dEnd = Convert.ToDateTime(EndDate);

            SqlParameter[] sqlParameters = { 
                    new SqlParameter { ParameterName = "Pid",Value = pid},
                    new SqlParameter{ParameterName = "Start",Value =dStart},
                    new SqlParameter{ParameterName="End",Value=dEnd}
             };
            return _repository.DataDbContext.Database.SqlQuery<CountPercentileModel>(sql, sqlParameters);
        }

        public IEnumerable<StatsLogNewModel> GetStatsLogListNew(int pid, string StartDate, string EndDate, string timeZone)
        {
            string sql = @"select *,
                        (CASE WHEN SubDate>'00:00:00' and SubDate<='02:30:00' then '02:30:00'
                        WHEN SubDate>'02:30:00' and SubDate<='05:00:00' then '05:00:00'
                        WHEN SubDate>'05:00:00' and SubDate<='07:30:00' then '07:30:00'
                        WHEN SubDate>'07:30:00' and SubDate<='10:00:00' then '10:00:00'
                        WHEN SubDate>'10:00:00' and SubDate<='12:30:00' then '12:30:00'
                        WHEN SubDate>'12:30:00' and SubDate<='15:00:00' then '15:00:00'
                        WHEN SubDate>'15:00:00' and SubDate<='17:30:00' then '17:30:00'
                        WHEN SubDate>'17:30:00' and SubDate<='20:00:00' then '20:00:00'
                        WHEN SubDate>'20:00:00' and SubDate<='22:30:00' then '22:30:00'
                        ELSE '00:00:00' END ) as TimeSplit
                        from 
                        (select *,Datepart(weekday,[timestamp]) as WeekDate,convert(char(8),[timestamp],108) as SubDate
                        from StatsLog
                        where [PMD ID]=@Pid and [timestamp] between @Start and @End
                        --where [PMD ID]=404685 and [timestamp] between '2015-1-20 00:00' and '2017-2-26 23:59'
                        ) s
                        order by TimeSplit ";

            DateTime dStart = Convert.ToDateTime(StartDate);
            DateTime dEnd = Convert.ToDateTime(EndDate);
            SqlParameter[] sqlParameters = { 
                    new SqlParameter { ParameterName = "Pid",Value = pid},
                    new SqlParameter{ParameterName = "Start",Value =dStart},
                    new SqlParameter{ParameterName="End",Value=dEnd}
             };
            return _repository.DataDbContext.Database.SqlQuery<StatsLogNewModel>(sql, sqlParameters);
        }
    }
}
