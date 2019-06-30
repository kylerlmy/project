namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class USERTYPEEntity : IEntity<USERTYPEEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public int UR_TYPE_ID { get; set; }
        public string UR_TYPE_NAME { get; set; }
        public string UR_TYPE_DESCRIPTION { get; set; }
    }
}
