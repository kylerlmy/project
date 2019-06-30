using System;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class MESSAGEEntity : IEntity<MESSAGEEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        public int DeviceID { get; set; }
        public byte? Category { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Message1 { get; set; }
        public byte? DeviceType { get; set; }
        public bool? IsDelete { get; set; }
    }
}
