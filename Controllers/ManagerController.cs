using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data;
using VPWebSolutions.Data.Enums;
using VPWebSolutions.Models;

namespace VPWebSolutions.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly BusinessDbContext _menuDb;

        public ManagerController(BusinessDbContext menuDbContext)
        {
            _menuDb = menuDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var orders = _menuDb.Orders
                .OrderBy(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem)
                .ToList();

            return View(orders);
        }

        public IActionResult EditStatus(int id)
        {
            var order = _menuDb.Orders.Find(id);
            
            ViewBag.Order = order;
            ViewBag.Refer = Request.Headers["Referer"].ToString();

            var model = new List<EditStatusViewModel>();
            foreach (var status in (OrderStatus[])Enum.GetValues(typeof(OrderStatus)))
            {
                var editStatusViewModel = new EditStatusViewModel
                {
                    returnUrl = ViewBag.Refer,
                    StatusName = status.ToString(),
                };
                if (order.Status == status)
                {
                    editStatusViewModel.Selected = true;
                }
                else
                {
                    editStatusViewModel.Selected = false;
                }
                model.Add(editStatusViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditStatus(List<EditStatusViewModel> model, int id)
        {
            var order = _menuDb.Orders.Find(id);
            foreach(var status in model)
            {
                if(status.Selected)
                {
                    order.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), status.StatusName);
                }
            }
            _menuDb.Orders.Update(order);
            _menuDb.SaveChanges();
            return RedirectToAction("Orders");
        }
    }
}
