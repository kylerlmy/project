using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
   public class COUNTRYYdMap:EntityTypeConfiguration<COUNTRYdEntity>
    {
        public COUNTRYYdMap()
        {
            ToTable("COUNTRY");
            HasKey(t => t.CTRY_ID);
        }
    }
}
