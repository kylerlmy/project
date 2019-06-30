using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
    public class CUSTOMERMap : EntityTypeConfiguration<CUSTOMEREntity>
    {
        public CUSTOMERMap()
        {
            ToTable("CUSTOMER");
            HasKey(t => t.CS_ID);
        }
    }
}
