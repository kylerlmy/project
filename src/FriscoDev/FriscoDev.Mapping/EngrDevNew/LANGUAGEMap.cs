using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;


namespace FriscoDev.Mapping.EngrDevNew
{
   public class LANGUAGEMap:EntityTypeConfiguration<LANGUAGEEntity>
    {
        public LANGUAGEMap()
        {
            ToTable("LANGUAGE");
            HasKey(t => t.LN_ID);
        }
    }
}
