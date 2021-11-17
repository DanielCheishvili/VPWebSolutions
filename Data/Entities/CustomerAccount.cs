using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VPWebSolutions.Data.Entities
{
    public class CustomerAccount : Account
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
    }
}
