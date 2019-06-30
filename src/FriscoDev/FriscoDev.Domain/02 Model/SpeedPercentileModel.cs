using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Domain.Model
{
    public class SpeedPercentileModel
    {
        public string TimeSplit { get; set; }
        public int MondayCount { get; set; }
        public int TuesdayCount { get; set; }
        public int WednesdayCount { get; set; }
        public int ThursdayCount { get; set; }
        public int FridayCount { get; set; }
        public int SaturdayCount { get; set; }
        public int SundayCount { get; set; }
    }
}
