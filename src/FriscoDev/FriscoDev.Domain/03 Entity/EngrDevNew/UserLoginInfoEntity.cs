using System;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class UserLoginInfoEntity : IEntity<UserLoginInfoEntity>, IDeleteAudited, ICreationAudited, IModificationAudited
    {
        public int Id { get; set; }
        public string UR_ID { get; set; }
        public string LoginName { get; set; }
        public DateTime? LoginTime { get; set; }
    }
}
