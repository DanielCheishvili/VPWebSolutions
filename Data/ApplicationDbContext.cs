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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Fries> Fries  { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<VPWebSolutions.Models.RegisterModel> RegisterModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("money");

            builder.Entity<OrderItem>()
                .Property(o => o.UnitPrice)
                .HasColumnType("money");

        }

        public DbSet<VPWebSolutions.Data.Entities.MenuItem> MenuItem { get; set; }
    }


}
