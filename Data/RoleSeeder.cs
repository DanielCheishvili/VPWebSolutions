using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public class RoleSeeder
    {

        private readonly UserIdentityDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleSeeder(UserIdentityDbContext context,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            _db.Database.EnsureCreated();

            //Seed Roles
            if (!_db.Roles.Any(r => r.Name == "Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            }
            if (!_db.Roles.Any(r => r.Name == "Manager"))
            {
                await _roleManager.CreateAsync(new IdentityRole(Enums.Roles.Manager.ToString()));
            }
            if (!_db.Roles.Any(r => r.Name == "Deliverer"))
            {
                await _roleManager.CreateAsync(new IdentityRole(Enums.Roles.Deliverer.ToString()));
            }
            if (!_db.Roles.Any(r => r.Name == "Employee"))
            {
                await _roleManager.CreateAsync(new IdentityRole(Enums.Roles.Employee.ToString()));
            }
            if (!_db.Roles.Any(r => r.Name == "Customer"))
            {
                await _roleManager.CreateAsync(new IdentityRole(Enums.Roles.Customer.ToString()));
            }
        }
    }
}
