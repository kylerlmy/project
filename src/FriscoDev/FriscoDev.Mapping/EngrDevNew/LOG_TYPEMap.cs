using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
    public class LOG_TYPEMap : EntityTypeConfiguration<LOG_TYPEEntity>
    {
        public LOG_TYPEMap()
        {
            ToTable("LOG_TYPE");
            HasKey(t => t.LOG_TYPE_ID);
        }
    }
}
