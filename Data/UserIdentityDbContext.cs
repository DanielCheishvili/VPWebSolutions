using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public class UserIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<VPWebSolutions.Models.RegisterModel> RegisterModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<VPWebSolutions.Models.EmployeeModel> EmployeeModel { get; set; }

    }
}
