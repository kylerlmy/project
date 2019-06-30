namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class EVENTEntity : IEntity<EVENTEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string EN_ID { get; set; }
        public int EN_TYPE { get; set; }
        public string DEV_ID { get; set; }
        public int VEH_TYPE_ID { get; set; }
        public System.DateTime EN_TIME { get; set; }
        public decimal EN_SPEED { get; set; }
        public string EN_DESC { get; set; }
    }
}
