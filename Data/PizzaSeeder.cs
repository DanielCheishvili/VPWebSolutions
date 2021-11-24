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
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;

        public PizzaSeeder(ApplicationDbContext ctx, IWebHostEnvironment hosting)
        {
            _db = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _db.Database.EnsureCreated();
            if(!_db.Pizzas.Any())
            {

                var pizzas = new List<Pizza>();

                var drinks = new List<Drink>();

                var orders = new List<Order>();

                var fries = new List<Fries>();

                var burgers = new List<Burger>();

                var cheesePizzaS = new Pizza()
                {
                    Price = 11.99,
                    Name = "Cheese",
                    ImageId = "cheesepizza",
                    Size = PizzaSize.Small
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
                    Name = "Pepperni",
                    ImageId = "PepperoniPizza",
                    Size = PizzaSize.Small
                };
                var pepPizzaM = new Pizza()
                {
                    Price = 16.99,
                    Name = "Pepperni",
                    ImageId = "PepperoniPizza",
                    Size = PizzaSize.Medium
                };
                var pepPizzaL = new Pizza()
                {
                    Price = 20.99,
                    Name = "Pepperni",
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

            }
                   
        }

    }
}
