using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class LOG_TYPEEntity : IEntity<LOG_TYPEEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public int LOG_TYPE_ID { get; set; }
        public string LOG_TYPE_DES { get; set; }
    }
}
