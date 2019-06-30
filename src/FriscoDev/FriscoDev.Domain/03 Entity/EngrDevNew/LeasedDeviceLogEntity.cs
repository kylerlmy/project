namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class LeasedDeviceLogEntity : IEntity<LeasedDeviceLogEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        public int Id { get; set; }
        public string IMSI { get; set; }
        public int? PMDID { get; set; }
        public string BelongName { get; set; }
        public System.DateTime LeasedStartDate { get; set; }
        public System.DateTime LeasedEndDate { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
