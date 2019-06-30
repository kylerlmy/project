using FriscoDev.Code;
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
    public class MessageApp
    {
        private IMESSAGERepository _repository = new MESSAGERepository();

        public int DeleteWarningMessage(int pmgId)
        {
            return _repository.Delete(t => t.DeviceID == pmgId);
        }
        public List<MESSAGEEntity> GetDeviceMessageList(string pmgId, 
            string startDate, int pageIndex, int pageSize, out int icount)
        {
            icount = 10;
            return _repository.IQueryable().ToList();
        }
        public bool CheckDeviceHasMsg(int pmgId)
        {
            var expression = ExtLinq.True<MESSAGEEntity>();
            expression = expression.And(t => t.DeviceID == pmgId);
            return _repository.IQueryable(expression).Count() > 0;
        }
    }
}
