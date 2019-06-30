using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class LANGUAGEEntity : IEntity<LANGUAGEEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string LN_ID { get; set; }
        public string LN_NAME { get; set; }
    }
}
