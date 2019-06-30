using System;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class LOGEntity : IEntity<LOGEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public int LOG_ID { get; set; }
        public int LOG_TYPE_ID { get; set; }
        public string LOG_DES { get; set; }
        public string LOG_USER_NAME { get; set; }
        public DateTime? LOG_TIME { get; set; }
    }
}
