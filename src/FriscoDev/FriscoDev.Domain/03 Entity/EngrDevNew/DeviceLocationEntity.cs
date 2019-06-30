using System;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class DeviceLocationEntity : IEntity<DeviceLocationEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public int ID { get; set; }
        public string IMSI { get; set; }
        public string Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
