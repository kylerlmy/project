using FriscoDev.Code;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.Domain.IRepository.EngrDevNew;
using FriscoDev.Repository.EngrDevNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace FriscoDev.Application.EngrDevNew
{
   public class PMDApp
    {
        private IPMDRepository _repository = new PMDRepository();

        public List<PMDEntity> GetPMDEntities()
        {
            return _repository.IQueryable().ToList();
        }
        public List<PMDEntity> GetPMDEntities(string userName, int type)
        {
            if (type == 1)
            {
                var exp = ExtLinq.True<PMDEntity>();
                exp = exp.And(t => t.Username == userName);
                return _repository.IQueryable(exp).ToList();
            }
            return _repository.IQueryable().ToList();
        }

        public PMDEntity GetPMGModel(string imsi)
        {
            var exp = ExtLinq.True<PMDEntity>();
            exp = exp.And(t => t.IMSI == imsi);
            return _repository.FindEntity(exp);

        }
        public List<PMDEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<PMDEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                //based on selected Conditions
            }
            return _repository.FindList(pagination);
        }
    }
}
