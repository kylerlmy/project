using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
   public class PMDMap:EntityTypeConfiguration<PMDEntity>
    {
        public PMDMap()
        {
            ToTable("PMD");
            HasKey(t => t.IMSI);
            Ignore(t => t.LastUpdate);
            Ignore(t => t.ShowConnection);
            Ignore(t => t.ShowStatsCollection);
            Ignore(t => t.ShowDeviceType);
            Property(t => t.PMD_ID).HasColumnName("PMD ID");
        }
    }
}
