namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class TimeZoneInfoEntity : IEntity<TimeZoneInfoEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public int Id { get; set; }
        public string ZoneValue { get; set; }
        public string ZoneName { get; set; }
    }
}
