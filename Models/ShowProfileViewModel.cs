using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VPWebSolutions.Data.Entities;

namespace VPWebSolutions.Models
{
    public class ShowProfileViewModel
    {
        public ShowProfileViewModel() { }

        [Key]
        [HiddenInput(DisplayValue =false)]
        public int UserDataId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public List<Order> Orders { get; set; }
    }
}
