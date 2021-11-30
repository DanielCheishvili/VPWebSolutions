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
        private readonly UserIdentityDbContext _Userdb;
        private readonly BusinessDbContext _Menudb;

        public OrderController(UserIdentityDbContext identityDbContext, BusinessDbContext menuDbContext)
        {
            _Userdb = identityDbContext;
            _Menudb = menuDbContext;
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
                .ToList();

            return View(orders);
        }

        [HttpGet("Order")]
        public IActionResult Order(int id)
        {
            var order = _Menudb.Orders.Find(id);
            return View(order);
        }
    }
}
