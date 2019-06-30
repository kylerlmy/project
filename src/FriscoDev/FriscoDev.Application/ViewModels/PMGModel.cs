using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Application.ViewModels
{
    public class PMGModel
    {
        public string PMDName { get; set; }
        public string IMSI { get; set; }
        public int DeviceType { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public Nullable<bool> Connection { get; set; }
        
        public Nullable<bool> StatsCollection { get; set; }
        public Nullable<int> PMD_ID { get; set; }
        public string CS_ID { get; set; }

        public string FirmwareVersion { get; set; }

        public string KeepAliveMessageInterval { get; set; }

        public string HighSpeedAlert { get; set; }
        public string LowSpeedAlert { get; set; }

        public string NewConfigurationTime { get; set; }
        public string LastUpdate
        {
            get
            {
                return DevFun.ConvertStrShowDate(NewConfigurationTime);
            }
        }

        public string ShowConnection
        {
            get
            {
                return DevFun.GetConvertStatus(Connection);
            }
        }

        public string ShowStatsCollection
        {
            get
            {
                return DevFun.GetConvertStatus(StatsCollection);
            }
        }
        public string ShowDeviceType
        {
            get
            {
                return DevFun.GetDeviceType(DeviceType);
            }
        }


    }


}
