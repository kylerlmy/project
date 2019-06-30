using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.Domain.IRepository.EngrDevNew;
using FriscoDev.Repository.EngrDevNew;
using System.Collections.Generic;
using System.Linq;

namespace FriscoDev.Application.EngrDevNew
{
    public class TimeZoneInfoApp
    {
        private ITimeZoneInfoRepository _repository = new TimeZoneInfoRepository();

        public List<TimeZoneInfoEntity> GetTimeZoneList()
        {
            return _repository.IQueryable().ToList();
        }
    }
}
