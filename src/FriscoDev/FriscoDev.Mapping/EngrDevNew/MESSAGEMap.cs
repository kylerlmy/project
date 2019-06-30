using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
   public class MESSAGEMap:EntityTypeConfiguration<MESSAGEEntity>
    {
        public MESSAGEMap()
        {
            ToTable("MESSAGE");
            HasKey(t => t.DeviceID);
        }
    }
}
