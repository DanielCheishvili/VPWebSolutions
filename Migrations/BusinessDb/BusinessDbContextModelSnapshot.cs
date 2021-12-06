﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VPWebSolutions.Data;

namespace VPWebSolutions.Migrations.BusinessDb
{
    [DbContext(typeof(BusinessDbContext))]
    partial class BusinessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShowProfileViewModelUserDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShowProfileViewModelUserDataId");

                    b.ToTable("IdentityRole");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdCustomer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MenuItem");

                    b.HasDiscriminator<string>("Discriminator").HasValue("MenuItem");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeliveryGuyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCustomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("OrderTotal")
                        .HasColumnType("real");

                    b.Property<int?>("ShowProfileViewModelUserDataId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserDataId")
                        .HasColumnType("int");

                    b.Property<bool>("isGuestUser")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShowProfileViewModelUserDataId");

                    b.HasIndex("UserDataId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("MenuItem_Id")
                        .HasColumnType("int");

                    b.Property<int>("OrderFK")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("MenuItem_Id");

                    b.HasIndex("OrderFK");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.UserData", b =>
                {
                    b.Property<int>("UserDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefferedAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserDataId");

                    b.ToTable("UserDatas");
                });

            modelBuilder.Entity("VPWebSolutions.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("VPWebSolutions.Models.CheckoutModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreditNumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderFK")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecurityCode")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("CheckOut");
                });

            modelBuilder.Entity("VPWebSolutions.Models.ContactModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("VPWebSolutions.Models.ShowProfileViewModel", b =>
                {
                    b.Property<int>("UserDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserDataId");

                    b.ToTable("ShowProfileViewModel");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.Burger", b =>
                {
                    b.HasBaseType("VPWebSolutions.Data.Entities.MenuItem");

                    b.HasDiscriminator().HasValue("Burger");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.Drink", b =>
                {
                    b.HasBaseType("VPWebSolutions.Data.Entities.MenuItem");

                    b.Property<int>("QuantityInMl")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Drink");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.Fries", b =>
                {
                    b.HasBaseType("VPWebSolutions.Data.Entities.MenuItem");

                    b.HasDiscriminator().HasValue("Fries");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.Pizza", b =>
                {
                    b.HasBaseType("VPWebSolutions.Data.Entities.MenuItem");

                    b.Property<string>("PizzaType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Pizza");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.HasOne("VPWebSolutions.Models.ShowProfileViewModel", null)
                        .WithMany("Roles")
                        .HasForeignKey("ShowProfileViewModelUserDataId");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.Order", b =>
                {
                    b.HasOne("VPWebSolutions.Models.ApplicationUser", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("VPWebSolutions.Models.ShowProfileViewModel", null)
                        .WithMany("Orders")
                        .HasForeignKey("ShowProfileViewModelUserDataId");

                    b.HasOne("VPWebSolutions.Data.Entities.UserData", "UserData")
                        .WithMany()
                        .HasForeignKey("UserDataId");

                    b.Navigation("Customer");

                    b.Navigation("UserData");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("VPWebSolutions.Data.Entities.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId");

                    b.HasOne("VPWebSolutions.Data.Entities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItem_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VPWebSolutions.Data.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("VPWebSolutions.Models.CheckoutModel", b =>
                {
                    b.HasOne("VPWebSolutions.Data.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("VPWebSolutions.Data.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("VPWebSolutions.Models.ShowProfileViewModel", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
