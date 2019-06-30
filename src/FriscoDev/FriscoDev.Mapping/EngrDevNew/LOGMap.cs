using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
   public class LOGMap:EntityTypeConfiguration<LOGEntity>
    {
        public LOGMap()
        {
            ToTable("LOG");
            HasKey(t => t.LOG_ID);
        }
    }
}
