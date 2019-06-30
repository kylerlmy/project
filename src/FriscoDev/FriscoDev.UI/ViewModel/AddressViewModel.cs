using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FriscoDev.UI.ViewModel
{
    public class AddressViewModel
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string ZipCode { get; set; }
        public string Direction { get; set; }
        public string CountryName { get; set; }
    }
}