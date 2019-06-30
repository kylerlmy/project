namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class CITYEntity : IEntity<CITYEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public System.Guid CITY_ID { get; set; }
        public string CTRY_ID { get; set; }
        public string CITY_NAME { get; set; }
        public string CITY_ABBR { get; set; }
    }
}
