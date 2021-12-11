using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Controllers
{
    public class SalesReportController : Controller
    {
        private readonly UserIdentityDbContext _Userdb;
        private readonly BusinessDbContext _Menudb;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPizzaRepository _pizzaRepository;
        public SalesReportController(UserIdentityDbContext identityDbContext, BusinessDbContext menuDbContext, UserManager<ApplicationUser> userManager)
        {
            _Userdb = identityDbContext;
            _Menudb = menuDbContext;
            _pizzaRepository = new PizzaRepository(menuDbContext);
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var model = new SalesReportModel();
            model.Orders = _Menudb.Orders
                .OrderBy(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem)
                .ToList();

            foreach (Order order in model.Orders)
            {
                foreach (OrderItem item in order.Items)
                {
                    var matches = model.Items.Where(p => p.MenuItem.Id == item.Id).ToList();
                    if (matches.Count() == 0)
                    {
                        model.Items.Add(item);
                    }
                    else
                    {
                        matches[0].Quantity++;
                    }
                }
            }

            return View(model);
        }
    }
}
