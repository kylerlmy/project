using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;


namespace FriscoDev.Mapping.EngrDevNew
{
    public class CITYMap : EntityTypeConfiguration<CITYEntity>
    {
        public CITYMap()
        {
            ToTable("CITY");
            HasKey(t => t.CITY_ID);
        }
    }
}
