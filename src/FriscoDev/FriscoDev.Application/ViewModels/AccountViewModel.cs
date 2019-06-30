using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Application.ViewModels
{
    public class AccountViewModel
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string UR_PASSWD { get; set; }
        public Nullable<bool> UR_ACTIVE { get; set; }
        public string AddTime { get; set; }
        

        public string ShowActive
        {
            get
            {
                return DevFun.GetConvertStatus(UR_ACTIVE);
            }
        }

    }
}
