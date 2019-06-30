using System;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class AccountEntity : IEntity<AccountEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string UR_ID { get; set; }
        public string UR_NAME { get; set; }
        public string UR_PASSWD { get; set; }
        public string UR_RealName { get; set; }
        public string CS_ID { get; set; }
        public string LN_ID { get; set; }
        public int UR_TYPE_ID { get; set; }
        public bool UR_ACTIVE { get; set; }
        public DateTime UR_ADDTIME { get; set; }
        public DateTime? UR_UPTIME { get; set; }
        public string UR_STATUS { get; set; }
        public bool? IS_ADMIN { get; set; }
        public string IMG_URL { get; set; }
        public string TIME_ZONE { get; set; }
        public string ZoomLevel { get; set; }
        public int? MessageDays { get; set; }
    }
}
