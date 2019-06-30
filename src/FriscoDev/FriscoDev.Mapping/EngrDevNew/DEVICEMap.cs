using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
   public class DEVICEMap:EntityTypeConfiguration<DEVICEEntity>
    {
        public DEVICEMap()
        {
            ToTable("DEVICE");
            HasKey(t => t.DEV_ID);
        }
    }
}
