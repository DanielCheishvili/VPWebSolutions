﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VPWebSolutions.Models
{
    public class ManageUserRolesViewModel
    {
        //public string returnUrl { get; set; }
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
