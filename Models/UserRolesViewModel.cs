using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VPWebSolutions.Models
{
    public class UserRolesViewModel
    {
        public string UserIdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
