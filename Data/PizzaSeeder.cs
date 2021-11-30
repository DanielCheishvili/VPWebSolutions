using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data.Entities;

namespace VPWebSolutions.Data
{
    public class PizzaSeeder
    {
        private readonly BusinessDbContext _db;
        private readonly IWebHostEnvironment _hosting;

        public PizzaSeeder(BusinessDbContext ctx, IWebHostEnvironment hosting)
        {
            _db = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _db.Database.EnsureCreated();
            if(!_db.Pizzas.Any())
            {
                #region Data

                var pizzas = new List<Pizza>();

                var drinks = new List<Drink>();

                var fries = new List<Fries>();

                var burgers = new List<Burger>();

                var cheesePizzaS = new Pizza()
                {
                    Price = 11.99,
                    Name = "Cheese",
                    ImageId = "cheesepizza",
                    Size = PizzaSize.Small,
                };
                var cheesePizzaM = new Pizza()
                {
                    Price = 16.99,
                    Name = "Cheese",
                    ImageId = "cheesepizza",
                    Size = PizzaSize.Medium
                };
                var cheesePizzaL = new Pizza()
                {
                    Price = 20.99,
                    Name = "Cheese",
                    ImageId = "cheesepizza",
                    Size = PizzaSize.Large
                };

                var pepPizzaS = new Pizza()
                {
                    Price = 11.99,
                    Name = "Pepperoni",
                    ImageId = "PepperoniPizza",
                    Size = PizzaSize.Small
                };
                var pepPizzaM = new Pizza()
                {
                    Price = 16.99,
                    Name = "Pepperoni",
                    ImageId = "PepperoniPizza",
                    Size = PizzaSize.Medium
                };
                var pepPizzaL = new Pizza()
                {
                    Price = 20.99,
                    Name = "Pepperoni",
                    ImageId = "PepperoniPizza",
                    Size = PizzaSize.Large
                };

                var vegPizzaS = new Pizza()
                {
                    Price = 11.99,
                    Name = "Veggie",
                    ImageId = "veggie",
                    Size = PizzaSize.Small
                };
                var vegPizzaM = new Pizza()
                {
                    Price = 16.99,
                    Name = "Veggie",
                    ImageId = "veggie",
                    Size = PizzaSize.Medium
                };
                var vegPizzaL = new Pizza()
                {
                    Price = 20.99,
                    Name = "Veggie",
                    ImageId = "veggie",
                    Size = PizzaSize.Large
                };

                var allDPizzaS = new Pizza()
                {
                    Price = 11.99,
                    Name = "All-Dressed",
                    ImageId = "AllDressed",
                    Size = PizzaSize.Small
                };
                var allDPizzaM = new Pizza()
                {
                    Price = 16.99,
                    Name = "All-Dressed",
                    ImageId = "AllDressed",
                    Size = PizzaSize.Medium
                };
                var allDPizzaL = new Pizza()
                {
                    Price = 20.99,
                    Name = "All-Dressed",
                    ImageId = "AllDressed",
                    Size = PizzaSize.Large
                };


                var cheeseburger = new Burger()
                {
                    Price = 6.99,
                    Name = "CheesBurger",
                    ImageId = "cheeseburger",
                    Type = MenuItemType.Burger
                    

                };
                var hamburger = new Burger()
                {
                    Price = 7.99,
                    Name = "Hamburger",
                    ImageId = "hamburger",
                    Type = MenuItemType.Burger

                };
                var chickenBurger = new Burger()
                {
                    Price = 7.99,
                    Name = "Chicken-Burger",
                    ImageId = "chickenBurger",
                    Type = MenuItemType.Burger

                };
                var veggieBurger = new Burger()
                {
                    Price = 9.99,
                    Name = "Veggie-Burger",
                    ImageId = "veggieburger",
                    Type = MenuItemType.Burger

                };


                var water = new Drink()
                {
                    Price = 2.00,
                    Name = "Water",
                    ImageId = "water",
                    Type = MenuItemType.Drink
                };
                var dietPepsi = new Drink()
                {
                    Price = 2.00,
                    Name = "Diet Pepsi",
                    ImageId = "dietPepsi",
                    Type = MenuItemType.Drink
                };
                var pepsi = new Drink()
                {
                    Price = 2.00,
                    Name = "Pepsi",
                    ImageId = "pepsi",
                    Type = MenuItemType.Drink
                };
                var coke = new Drink()
                {
                    Price = 2.00,
                    Name = "Coke",
                    ImageId = "coke",
                    Type = MenuItemType.Drink
                };
                var dietCoke = new Drink()
                {
                    Price = 2.00,
                    Name = "Diet Coke",
                    ImageId = "dietcoke",
                    Type = MenuItemType.Drink
                };
                var sevenUp = new Drink()
                {
                    Price = 2.00,
                    Name = "7Up",
                    ImageId = "7up",
                    Type = MenuItemType.Drink
                };
                var gingerAle = new Drink()
                {
                    Price = 2.00,
                    Name = "Gingel-Ale",
                    ImageId = "gingerale",
                    Type = MenuItemType.Drink
                };
                var fanta = new Drink()
                {
                    Price = 2.00,
                    Name = "Fanta",
                    ImageId = "fanta",
                    Type = MenuItemType.Drink
                };


                var regFries = new Fries()
                {
                    Price = 3.50,
                    Name = "Fries",
                    ImageId = "fries",
                    Type = MenuItemType.Fries
                };
                var wedges = new Fries()
                {
                    Price = 3.50,
                    Name = "Wedges",
                    ImageId = "wedges",
                    Type = MenuItemType.Fries
                };
                var hashbrown = new Fries()
                {
                    Price = 3.50,
                    Name = "Hashbrown",
                    ImageId = "fries",
                    Type = MenuItemType.Fries
                };
                var rings = new Fries()
                {
                    Price = 3.50,
                    Name = "Rings",
                    ImageId = "rings",
                    Type = MenuItemType.Fries
                };




                #endregion

                #region adding To DB
                pizzas.Add(cheesePizzaS);
                pizzas.Add(cheesePizzaM);
                pizzas.Add(cheesePizzaL);
                pizzas.Add(vegPizzaS);
                pizzas.Add(vegPizzaM);
                pizzas.Add(vegPizzaL);
                pizzas.Add(pepPizzaS);
                pizzas.Add(pepPizzaM);
                pizzas.Add(pepPizzaL);
                pizzas.Add(allDPizzaS);
                pizzas.Add(allDPizzaM);
                pizzas.Add(allDPizzaL);

                burgers.Add(cheeseburger);
                burgers.Add(veggieBurger);
                burgers.Add(hamburger);
                burgers.Add(chickenBurger);

                drinks.Add(water);
                drinks.Add(dietPepsi);
                drinks.Add(pepsi);
                drinks.Add(coke);
                drinks.Add(dietCoke);
                drinks.Add(sevenUp);
                drinks.Add(gingerAle);
                drinks.Add(fanta);

                fries.Add(regFries);
                fries.Add(wedges);
                fries.Add(hashbrown);
                fries.Add(rings);

                _db.Pizzas.AddRange(pizzas);
                _db.Burgers.AddRange(burgers);
                _db.Drinks.AddRange(drinks);
                _db.Fries.AddRange(fries);
                #endregion
                _db.SaveChanges();
            }

        }

    }
}
