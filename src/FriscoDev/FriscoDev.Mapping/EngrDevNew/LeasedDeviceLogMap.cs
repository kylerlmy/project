using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;


namespace FriscoDev.Mapping.EngrDevNew
{
  public  class LeasedDeviceLogMap:EntityTypeConfiguration<LeasedDeviceLogEntity>
    {
        public LeasedDeviceLogMap()
        {
            ToTable("LeasedDeviceLog");
            HasKey(t => t.Id);
        }
    }
}
