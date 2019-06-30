namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class TIMEZONEEntity : IEntity<TIMEZONEEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string TZ_ID { get; set; }
        public string TZ_DESC { get; set; }
    }
}
