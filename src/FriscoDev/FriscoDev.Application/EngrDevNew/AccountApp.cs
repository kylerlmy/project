using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.Domain.IRepository.EngrDevNew;
using FriscoDev.Repository.EngrDevNew;
using System;
using System.Collections.Generic;
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

    }
}
