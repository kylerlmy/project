using FriscoDev.Code;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.Domain.IRepository.EngrDevNew;
using FriscoDev.Repository.EngrDevNew;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Application.EngrDevNew
{
   public class AccountApp
    {
        private IAccountReposiory _repository = new AccountRepository();

        public AccountEntity GetAccountEntity(string userName, string password)
        {
            return _repository.FindEntity(t => t.UR_NAME == userName && t.UR_PASSWD == password);
        }
        public AccountEntity GetAccountEntities(string userName)
        {
            return _repository.FindEntity(t => t.UR_NAME == userName);
        }
        public void Add(AccountEntity entity)
        {
            _repository.Insert(entity);
        }
        public string GetParentIDByUser(string UserId)
        {
            string sql = @" SELECT TOP 1 [UR_ID]
                            FROM [Account]
                            where [UR_TYPE_ID]=2 and CS_ID=(select CS_ID from [Account] where [UR_ID]=@UR_ID )";
            DbParameter[] parameter =
              {
                  new SqlParameter("@UR_ID ",UserId)
              };
            return _repository.FindList(sql, parameter).FirstOrDefault()?.UR_ID;
        }

    }
}
