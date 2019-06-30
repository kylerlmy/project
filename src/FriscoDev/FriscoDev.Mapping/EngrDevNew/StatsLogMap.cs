using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
    public class StatsLogMap : EntityTypeConfiguration<StatsLogEntity>
    {
        public StatsLogMap()
        {
            ToTable("StatsLog");
            HasKey(t => t.PMD_ID);
        }
    }
}
