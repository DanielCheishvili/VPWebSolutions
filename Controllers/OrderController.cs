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
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Orders")]
        public IActionResult Orders()
        {
            var orders = _db.Orders
                .OrderBy(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.Status == Data.Entities.OrderStatus.COOKED || o.Status == Data.Entities.OrderStatus.OUT_FOR_DELIVERY)
                .Where(o => o.DeliveryGuyId == null || o.DeliveryGuyId == _userManager.GetUserAsync(User).Result.Id)
                .ToList();

            foreach(var order in orders)
            {
                var cust = _userManager.FindByIdAsync(order.CustomerId);
                if (cust != null)
                {
                    order.Customer = cust.Result;
                }
            }
            return View(orders);
        }

        [HttpGet("Order")]
        //TODO only dellivery ppl and higher ups can see this
        public IActionResult Order(int id)
        {
            var order = _db.Orders.Find(id);
            return View(order);
        }

        public IActionResult UpdateStatus(int id)
        {
            var order = _db.Orders.Find(id);
            order.Status = order.Status.Next();
            order.DeliveryGuyId = _userManager.GetUserAsync(User).Result.Id;
            _db.Orders.Update(order);
            _db.SaveChanges();

            return RedirectToAction("Orders", "Order");
        }
    }
}
