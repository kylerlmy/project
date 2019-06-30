using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
   public class DeviceLocationMap:EntityTypeConfiguration<DeviceLocationEntity>
    {
        public DeviceLocationMap()
        {
            ToTable("DeviceLocaiton");
            HasKey(t => t.ID);
        }
    }
}
