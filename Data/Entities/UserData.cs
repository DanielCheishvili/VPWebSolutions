using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VPWebSolutions.Data.Entities
{
    public class UserData
    {
        [Key]
        public int UserDataId { get; set; }
        public string IdentityUserId { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public string PrefferedAddress { get; set; }
        public List<Order> Orders;
    }
}
