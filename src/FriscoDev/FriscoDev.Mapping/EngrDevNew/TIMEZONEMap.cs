using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
   public class TIMEZONEMap:EntityTypeConfiguration<TIMEZONEEntity>
    {
        public TIMEZONEMap()
        {
            ToTable("TIMEZONE");
            HasKey(t => t.TZ_ID);
        }
    }
}
