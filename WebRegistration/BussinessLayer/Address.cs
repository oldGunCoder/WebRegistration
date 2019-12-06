using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRegistration.BussinessLayer
{
    public class Address
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}