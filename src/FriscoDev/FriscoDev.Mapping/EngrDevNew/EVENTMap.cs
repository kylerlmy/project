using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;


namespace FriscoDev.Mapping.EngrDevNew
{
   public class EVENTMap:EntityTypeConfiguration<EVENTEntity>
    {
        public EVENTMap()
        {
            ToTable("EVENT");
            HasKey(t => t.EN_ID);
        }
    }
}
