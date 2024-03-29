﻿using Microsoft.AspNetCore.Identity;
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
                await _userManager.AddToRoleAsync(manager, Roles.Manager.ToString());
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

            ApplicationUser manager2 = await _userManager.FindByEmailAsync("manager2@user.com");
            if (manager2 == null)
            {
                manager2 = new ApplicationUser()
                {
                    UserName = "manager2@user.com",
                    Email = "manager2@user.com"
                };
                var result = await _userManager.CreateAsync(manager2, "Test123!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
                await _userManager.AddToRoleAsync(manager2, "Manager");
            }

            ApplicationUser deliverer2 = await _userManager.FindByEmailAsync("deliverer2@user.com");
            if (deliverer2 == null)
            {
                deliverer2 = new ApplicationUser()
                {
                    UserName = "deliverer2@user.com",
                    Email = "deliverer2@user.com"
                };
                var result = await _userManager.CreateAsync(deliverer2, "Test123!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
                await _userManager.AddToRoleAsync(deliverer2, "Deliverer");
            }

            ApplicationUser cook2 = await _userManager.FindByEmailAsync("cook2@user.com");
            if (cook2 == null)
            {
                cook2 = new ApplicationUser()
                {
                    UserName = "cook2@user.com",
                    Email = "cook2@user.com"
                };
                var result = await _userManager.CreateAsync(cook2, "Test123!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
                await _userManager.AddToRoleAsync(cook2, "Cook");
            }

            ApplicationUser employee = await _userManager.FindByEmailAsync("emp@user.com");
            if (employee == null)
            {
                employee = new ApplicationUser()
                {
                    UserName = "emp@user.com",
                    Email = "emp@user.com"
                };
                var result = await _userManager.CreateAsync(employee, "Test123!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }

                await _userManager.AddToRoleAsync(employee, Roles.Employee.ToString());
}
        }
    }
}
