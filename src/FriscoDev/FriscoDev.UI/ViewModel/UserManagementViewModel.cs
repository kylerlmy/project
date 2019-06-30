using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FriscoDev.UI.ViewModel;
using FriscoDev.Domain.Entity.EngrDevNew;

namespace FriscoDev.UI.ViewModel
{
    public class UserManagementViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public class UserViewModel
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string RealName { get; set; }
            public string UserType { get; set; }
            public int HideUserType { get; set; }
            public string Customer { get; set; }
            public string Active { get; set; }
            public int ActiveType { get; set; }
            public string IsAdmin { get; set; }
            public string ImgUrl { get; set; }
            public string TimeZone { get; set; }
            public string SiteName { get; set; }
            public string ProfileImgUrl { get; set; }
            public string LastLoginTime { get; set; }
        }

        public class AddUserModel : SiteConfigEntity
        {
            public string RealName { get; set; }

            public string UserName { get; set; }
            public string Password { get; set; }
            public string RepeatPassword { get; set; }
            public int SelectedUserType { get; set; }

        }

        public class EditUserModel : SiteConfigEntity
        {
            public string RealName { get; set; }
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
            public string RepeatNewPassword { get; set; }
            public int SelectedUserType { get; set; }

            public string ImgUrl { get; set; }

            public int UR_TYPE_ID { get; set; }
            public string ShowLoginTime { get; set; }
            public int ActiveType { get; set; }
        }


    }
}