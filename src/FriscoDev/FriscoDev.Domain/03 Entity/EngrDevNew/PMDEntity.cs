using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class PMDEntity : IEntity<PMDEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        public string PMDName { get; set; }
        public string IMSI { get; set; }
        public int DeviceType { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public bool Connection { get; set; }
        public bool StatsCollection { get; set; }
        public int? PMD_ID { get; set; }
        public byte[] CurrentConfiguration { get; set; }
        public string CurrrentConfigurationTime { get; set; }
        public byte[] NewConfiguration { get; set; }
        public string NewConfigurationTime { get; set; }
        public string Clock { get; set; }
        public string FirmwareVersion { get; set; }
        public string NewFirmwareId { get; set; }
        public int? NumFirmwareUpdateAttempts { get; set; }
        public int? KeepAliveMessageInterval { get; set; }
        public string CS_ID { get; set; }
        public byte? HighSpeedAlert { get; set; }
        public byte? LowSpeedAlert { get; set; }

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
