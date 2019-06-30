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
   public class UserLoginInfoApp
    {
       private IUserLogInfoRepository _repository = new UserLogInfoRepository();

       public void AddLoginInfo(UserLoginInfoEntity info)
       {
           _repository.Insert(info);
       }
    }
}
