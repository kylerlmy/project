using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;


namespace FriscoDev.Mapping.EngrDevNew
{
    public class DeviceNamesMap : EntityTypeConfiguration<DeviceNamesEntity>
    {
        public DeviceNamesMap()
        {
            ToTable("DeviceNames");
            HasKey(t => t.DeviceType);
        }
    }
}
