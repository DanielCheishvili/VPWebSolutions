using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data.Enums;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public class IdentitySeeder
    {
        private readonly UserIdentityDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentitySeeder(UserIdentityDbContext context,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            _db.Database.EnsureCreated();

            ApplicationUser admin = await _userManager.FindByEmailAsync("admin@user.com");
            if(admin == null)
            {
                admin = new ApplicationUser()
                {
                    UserName = "admin@user.com",
                    Email = "admin@user.com"
                };
                var result = await _userManager.CreateAsync(admin, "Test123!");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
                await _userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
            }

            ApplicationUser manager = await _userManager.FindByEmailAsync("manager@user.com");
            if (manager == null)
            {
                manager = new ApplicationUser()
                {
                    UserName = "manager@user.com",
                    Email = "manager@user.com"
                };
                var result = await _userManager.CreateAsync(manager, "Test123!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
                await _userManager.AddToRoleAsync(admin, Roles.Manager.ToString());
            }

            ApplicationUser deliverer = await _userManager.FindByEmailAsync("deliverer@user.com");
            if (deliverer == null)
            {
                deliverer = new ApplicationUser()
                {
                    UserName = "deliverer@user.com",
                    Email = "deliverer@user.com"
                };
                var result = await _userManager.CreateAsync(deliverer, "Test123!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
                await _userManager.AddToRoleAsync(deliverer, Roles.Deliverer.ToString());
            }

            ApplicationUser cook = await _userManager.FindByEmailAsync("cook@user.com");
            if (cook == null)
            {
                cook = new ApplicationUser()
                {
                    UserName = "cook@user.com",
                    Email = "cook@user.com"
                };
                var result = await _userManager.CreateAsync(cook, "Test123!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
                await _userManager.AddToRoleAsync(cook, Roles.Cook.ToString());
            }
        }
    }
}
