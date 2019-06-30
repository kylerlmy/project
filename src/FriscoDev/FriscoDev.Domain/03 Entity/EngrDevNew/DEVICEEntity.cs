using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class DEVICEEntity : IEntity<DEVICEEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        public string DEV_ID { get; set; }
        public string DEV_NAME { get; set; }
        public string DEV_CODE { get; set; }
        public string CS_ID { get; set; }
        public int DEV_TYPE { get; set; }
        public decimal? DEV_COORDINATE_X { get; set; }
        public decimal? DEV_COORDINATE_Y { get; set; }
        public string DEV_ADDRESS { get; set; }
        public bool DEV_ACTIVE { get; set; }
        public System.DateTime DEV_ADDTIME { get; set; }
        public DateTime? DEV_UPTIME { get; set; }
        public int? PMD_ID { get; set; }
        public string CCID { get; set; }
    }
}
