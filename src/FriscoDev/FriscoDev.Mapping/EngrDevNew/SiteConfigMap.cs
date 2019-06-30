using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
    public class SiteConfigMap : EntityTypeConfiguration<SiteConfigEntity>
    {
        public SiteConfigMap()
        {
            ToTable("SiteConfig");
            HasKey(t => t.Id);
        }
    }
}
