﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriscoDev.Application.ViewModels
{
    public class SiteConfig
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string ProfileImgUrl { get; set; }
        public string Login_UR_ID { get; set; }
        public string Default_Location { get; set; }
        public string TimeZone { get; set; }
        public string Organization { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryName { get; set; }
        public string Address { get; set; }
    }
}
