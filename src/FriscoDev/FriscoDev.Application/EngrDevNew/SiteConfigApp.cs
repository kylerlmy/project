using FriscoDev.Code;
using FriscoDev.Domain.Entity.EngrDevNew;
using FriscoDev.Domain.IRepository.EngrDevNew;
using FriscoDev.Domain.Model;
using FriscoDev.Repository.EngrDevNew;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace FriscoDev.Application.EngrDevNew
{
    public class SiteConfigApp
    {
        private ISiteConfigRepository _repository = new SiteConfigRepository();
        public void SaveSiteConfig(SiteConfigEntity entity)
        {
            _repository.Update(entity);
        }
        public void AddSiteConfig(SiteConfigEntity entity)
        {
            _repository.Insert(entity);
        }
        public SiteConfigEntity GetSiteConfig()
        {
            var expression = ExtLinq.True<SiteConfigEntity>();
            expression = expression.And(t => t.Id == 1);
            return _repository.FindEntity(expression);
        }
        public SiteConfigEntity GetSiteConfigByUser(string UserId)
        {
            var expression = ExtLinq.True<SiteConfigEntity>();
            expression = expression.And(t => t.Login_UR_ID == UserId);
            return _repository.FindEntity(expression);
        }
        public int GetIsExistSiteConfigByUser(string UserId)
        {
            var expression = ExtLinq.True<SiteConfigEntity>();
            expression = expression.And(t => t.Login_UR_ID == UserId);
            return _repository.IQueryable(expression).Count();
        }
    }
}
