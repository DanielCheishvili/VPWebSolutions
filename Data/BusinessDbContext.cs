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
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext(DbContextOptions<BusinessDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Fries> Fries { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Deals> Deals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<MenuItem> CartItems { get; set; }

        public DbSet<CheckoutModel> CheckOut { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("money");

            builder.Entity<OrderItem>()
                .Property(o => o.UnitPrice)
                .HasColumnType("money");

            builder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderFK);

            base.OnModelCreating(builder);
        }

        public DbSet<VPWebSolutions.Data.Entities.MenuItem> MenuItem { get; set; }

        public DbSet<VPWebSolutions.Models.ShowProfileViewModel> ShowProfileViewModel { get; set; }
    }
}
