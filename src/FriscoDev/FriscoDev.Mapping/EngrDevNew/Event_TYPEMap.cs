using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;


namespace FriscoDev.Mapping.EngrDevNew
{
   public class EVENT_TYPEMap:EntityTypeConfiguration<EVENT_TYPEEntity>
    {
        public EVENT_TYPEMap()
        {
            ToTable("EVENT_TYPE");
            HasKey(t => t.EN_TYPE_ID);
        }
    }
}
