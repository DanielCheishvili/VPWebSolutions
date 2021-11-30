using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data;
using VPWebSolutions.Models;

namespace VPWebSolutions.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserIdentityDbContext _Userdb;
        private readonly BusinessDbContext _Menudb;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPizzaRepository _pizzaRepository;

        public OrderController(UserIdentityDbContext identityDbContext, BusinessDbContext menuDbContext, UserManager<ApplicationUser> userManager)
        {
            _Userdb = identityDbContext;
            _Menudb = menuDbContext;
            _pizzaRepository = new PizzaRepository(menuDbContext);
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Orders")]
        public IActionResult Orders()
        {
            var orders = _Menudb.Orders
                .OrderBy(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem)
                //.Where(o => o.Status == Data.Entities.OrderStatus.COOKED || o.Status == Data.Entities.OrderStatus.OUT_FOR_DELIVERY)
                //.Where(o => o.DeliveryGuyId =s= null || o.DeliveryGuyId == _userManager.GetUserAsync(User).Result.Id)
                .ToList();

            foreach (var order in orders)
            {
                var cust = _userManager.FindByIdAsync(order.IdCustomer);
                if (cust != null)
                {
                    order.Customer = cust.Result;
                }
            }

            return View(orders);
        }

        [HttpGet("Order")]
        public IActionResult Order(int id)
        {
            var order = _Menudb.Orders.Find(id);
            order.Status = order.Status.Next();
            order.DeliveryGuyId = _userManager.GetUserAsync(User).Result.Id;
            _Menudb.Orders.Update(order);
            return View(order);
        }
    }
}
