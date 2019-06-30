using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
    public class PMDConfigMap : EntityTypeConfiguration<PMDConfigEntity>
    {
        public PMDConfigMap()
        {
            ToTable("PMDConfig");
            HasKey(t => t.Id);
        }
    }
}
