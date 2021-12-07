using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Deliverer")]
        public IActionResult Orders()
        {
            var orders = _Menudb.Orders
                .OrderBy(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.Status == Data.Entities.OrderStatus.COOKED || o.Status == Data.Entities.OrderStatus.IN_DELIVERY)
                .Where(o => o.DeliveryGuyId == null || o.DeliveryGuyId == _userManager.GetUserAsync(User).Result.Id)
                .ToList();

            foreach (var order in orders)
            {
                /*
                if(order.isGuestUser)
                {
                    var checkoutInfo = _Menudb.CheckOut.Where(co => co.Order.Id == order.Id).ToList();
                    if (checkoutInfo.Count() > 0)
                    {
                        order.Customer = new ApplicationUser { Address = checkoutInfo[0].Address };
                    }
                }
                else
                {
                    var cust = _userManager.FindByIdAsync(order.IdCustomer);
                    if (cust != null)
                    {
                        order.Customer = cust.Result;
                    }
                }
                */
            }

            return View(orders);
        }

        public IActionResult UpdateStatus(int id)
        {
            var order = _Menudb.Orders.Find(id);
            order.Status = order.Status.Next();
            order.DeliveryGuyId = _userManager.GetUserAsync(User).Result.Id;
            _Menudb.Orders.Update(order);
            _Menudb.SaveChanges();
            return RedirectToAction("Orders", "Order");
        }
    }
}
