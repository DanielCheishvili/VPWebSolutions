using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            ApplicationUser admin = await _userManager.FindByEmailAsync("test@user.com");

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

                if(!_db.Roles.Any(r => r.Name == "Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
                }

                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            ApplicationUser delivery = await _userManager.FindByEmailAsync("delguy@user.com");

            if (delivery == null)
            {
                delivery = new ApplicationUser()
                {
                    UserName = "delguy@user.com",
                    Email = "delguy@user.com"
                };
                var result = await _userManager.CreateAsync(delivery, "Test123!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }

                if (!_db.Roles.Any(r => r.Name == "Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = "Deliverer", NormalizedName = "Deliverer" });
                }

                await _userManager.AddToRoleAsync(delivery, "Deliverer");
            }
        }
    }
}
