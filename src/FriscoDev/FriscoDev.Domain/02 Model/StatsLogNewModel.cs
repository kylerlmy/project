using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Domain.Model
{
    public class StatsLogNewModel
    {
        public long RowNumber { get; set; }
        public int TargetId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Direction { get; set; }
        public double LastSpeed { get; set; }
        public double PeakSpeed { get; set; }
        public double AverageSpeed { get; set; }
        public int Strength { get; set; }
        public string Classfication { get; set; }
        public int Duration { get; set; }
        public int PMDID { get; set; }

        public string StatDate { get; set; }

        public string StatDate2 { get; set; }

        public string StrTimestamp { get; set; }
        public int WeekDate { get; set; }
        public string SubDate { get; set; }
        public string TimeSplit { get; set; }
    }
}
