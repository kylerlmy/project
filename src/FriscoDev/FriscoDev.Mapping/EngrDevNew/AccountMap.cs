using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
   public class AccountMap : EntityTypeConfiguration<AccountEntity>
    {
        public AccountMap()
        {
            ToTable("Account");
            HasKey(t => t.UR_ID);
            
        }
    }
}
