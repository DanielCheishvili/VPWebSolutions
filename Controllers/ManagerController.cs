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
using VPWebSolutions.Data.Enums;
using VPWebSolutions.Models;

namespace VPWebSolutions.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly BusinessDbContext _menuDb;
        private readonly UserManager<ApplicationUser> _userManager;


        public ManagerController(BusinessDbContext menuDbContext, UserManager<ApplicationUser> userManager)
        {
            _menuDb = menuDbContext;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var orders = _menuDb.Orders
                .OrderByDescending(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem)
                .ToList();

            foreach (var order in orders)
            {
                if (order.isGuestUser)
                {
                    var checkoutInfo = _menuDb.CheckOut.Where(co => co.Order.Id == order.Id).ToList();
                    if (checkoutInfo.Count() > 0)
                    {
                        order.UserData = new UserData { FullName = checkoutInfo[0].FirstName + " " + checkoutInfo[0].LastName };
                    }
                }
                else
                {
                    var cust = _menuDb.UserDatas.Where(u => u.UserDataId == order.IdCustomer).FirstOrDefault();
                    if (cust != null)
                    {
                        order.UserData = cust;
                    }
                }
            }

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

        public IActionResult OrderDetails(int id)
        {
            var orders = _menuDb.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem);
            var order = orders.First(o => o.Id == id);
            return View(order);
        }
    }
}
