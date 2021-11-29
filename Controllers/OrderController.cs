using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data;

namespace VPWebSolutions.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
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
                .ToList();

            return View(orders);
        }

        [HttpGet("Order")]
        public IActionResult Order(int id)
        {
            var order = _db.Orders.Find(id);
            return View(order);
        }

        public IActionResult UpdateStatus(int id)
        {
            var order = _db.Orders.Find(id);
            order.Status = order.Status.Next();
            _db.Orders.Update(order);
            _db.SaveChanges();

            return RedirectToAction("Orders", "Order");
        }
    }
}
