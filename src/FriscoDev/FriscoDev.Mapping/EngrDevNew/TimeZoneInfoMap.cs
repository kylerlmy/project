using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
    public class TimeZoneInfoMap : EntityTypeConfiguration<TimeZoneInfoEntity>
    {
        public TimeZoneInfoMap()
        {
            ToTable("TimeZoneInfo");
            HasKey(t => t.Id);
        }
    }
}
