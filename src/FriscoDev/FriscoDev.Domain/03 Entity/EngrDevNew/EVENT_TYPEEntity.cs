namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class EVENT_TYPEEntity : IEntity<EVENT_TYPEEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public int EN_TYPE_ID { get; set; }
        public string EN_TYPE_NAME { get; set; }
        public string EN_TYPE_DESC { get; set; }
    }
}
