using FriscoDev.Domain.Entity.EngrDevNew;
using System.Data.Entity.ModelConfiguration;

namespace FriscoDev.Mapping.EngrDevNew
{
    public class UserLoginInfoMap : EntityTypeConfiguration<UserLoginInfoEntity>
    {
        public UserLoginInfoMap()
        {
            ToTable("UserLoginInfo");
            HasKey(t => t.Id);
        }
    }
}
