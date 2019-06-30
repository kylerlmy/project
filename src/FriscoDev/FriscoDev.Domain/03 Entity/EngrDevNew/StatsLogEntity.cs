namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class StatsLogEntity : IEntity<StatsLogEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public short Target_ID { get; set; }
        public System.DateTime Timestamp { get; set; }
        public string Direction { get; set; }
        public decimal? LastSpeed { get; set; }
        public decimal? PeakSpeed { get; set; }
        public decimal? AverageSpeed { get; set; }
        public byte? Strength { get; set; }
        public string Classfication { get; set; }
        public short? Duration { get; set; }
        public short? Product_ID { get; set; }
        public int PMD_ID { get; set; }
    }
}
