using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public class BusinessDataSeeder​
    {
        private readonly BusinessDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        // Inject Business DB context and user manager​
        public BusinessDataSeeder(BusinessDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        public async void SeedAsync()
        {
            //  Make sure the database is created before we make any queries.​
            //  Will create the database if it doesn't exist yet (and thereby avoid errors)​
            _db.Database.EnsureCreated();
            // If there are no userdatas, then load/create sample userdata​
            if (!_db.UserDatas.Any())
            {
                ApplicationUser user = await _userManager.FindByEmailAsync("test@user.com");
                if (user == null)
                {
                    throw new InvalidOperationException("Could not seed business data due to missing seed user");
                }

                // Create sample UserData​
                UserData userData = new UserData​
                {
                    IdentityUserId = user.Id,
                    PrefferedAddress = "900 Park Ave",
                    Orders = new List<Order>()
                };
                // Now, let's create a sample order​
                var order = new Order()
                {
                    OrderNumber = "10000",
                    OrderTotal = 123.45f,
                    UserData = userData
                };
                userData.Orders.Add(order);
                _db.UserDatas.Add(userData);
                _db.Orders.Add(order);
                // Actually write the changes to the database
                // This will figure out all the foreign keys, etc to reflect the correct mappings.​
                _db.SaveChanges();
            }
        }
    }
}
