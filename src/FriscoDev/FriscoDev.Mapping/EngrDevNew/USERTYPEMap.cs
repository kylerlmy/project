using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
   public class USERTYPEMap:EntityTypeConfiguration<USERTYPEEntity>
    {
        public USERTYPEMap()
        {
            ToTable("USERTYPE");
            HasKey(t => t.UR_TYPE_ID);
        }
    }
}
