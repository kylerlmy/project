namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class COUNTRYdEntity : IEntity<COUNTRYdEntity>, IDeleteAudited, ICreationAudited, IModificationAudited
    {
        public string CTRY_ID { get; set; }
        public string CTRY_NAME { get; set; }
        public string CTRY_ABBR { get; set; }
    }
}
