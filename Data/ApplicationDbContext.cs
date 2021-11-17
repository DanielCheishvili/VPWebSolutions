using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ContactModel> Contacts { get; set; }

        public DbSet<VPWebSolutions.Models.RegisterModel> RegisterModel { get; set; }
    }


}
