using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VPWebSolutions.Data;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Data.Enums;
using VPWebSolutions.Logic;
using VPWebSolutions.Models;

namespace VPWebSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        //Instantiating the IEmailSender interface using Dependency Injection
        private readonly UserIdentityDbContext _Userdb;
        private readonly BusinessDbContext _Menudb;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, IConfiguration configuration, UserIdentityDbContext identityDbContext, BusinessDbContext menuDbContext, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager )
        {
            _logger = logger;
            _emailSender = emailSender;
            _configuration = configuration;
            _Userdb = identityDbContext;
            _Menudb = menuDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost("Contact")]
        public async Task<IActionResult> ContactAsync(ContactModel contact)
        {
            if (ModelState.IsValid && IsReCaptchValid())
            {
                //Send the email
                await _emailSender.SendEmailAsync(contact.Email, contact.Topic, contact.Message);
                //Add contact model to the database
                _Menudb.Contacts.Add(contact);
                _Menudb.SaveChanges();
                //Call the view success and send the contact model
                return View("Success", contact);
            }
            if (!IsReCaptchValid())
            {
                ViewData["ErrorMessage"] = "Please verify that you're not a robot.";
            }
            return View();
        }

        [HttpGet("About")]
        public IActionResult About()
        {
            return View();
        }
        [HttpGet("Career")]
        public IActionResult Career()
        {
            return View();
        }

        [HttpGet("Menu")]
        public IActionResult Menu()
        {

            var results = _Menudb.MenuItem.ToList();
        
            return View(results);
        }
        [HttpGet("Cart")]
        public IActionResult Cart(){
            
            return View();
            
        }

        [HttpPost]
        public IActionResult CartAdd(int ItemId)
        {
            var itemAdd = _Menudb.MenuItem.Find(ItemId);
            var matches = CartActions.listItems.Where(p => p.MenuItem.Id == ItemId).ToList();
            if (matches.Count() == 0)
            {
                CartActions.listItems.Add(new OrderItem
                {

                    MenuItem_Id = itemAdd.Id,
                    MenuItem = itemAdd,
                    Quantity = 1,
                    UnitPrice = itemAdd.Price,
                });
            }
            else
            {
                matches[0].Quantity++;
            }
            

            return RedirectToAction("Menu", "Home");
        }

        [HttpPost]
        public IActionResult CartRemove(int ItemId)
        {
            var matches = CartActions.listItems.Where(p => p.MenuItem.Id == ItemId).ToList();
            if (matches.Count > 1)
            {
                foreach (var item in matches)
                {
                    
                    CartActions.listItems.Remove(item);
                }
            }
            

                return RedirectToAction("Cart", "Home");
        }

        
        [HttpGet("Checkout")]
        public IActionResult Checkout(CheckoutModel model)
        {
            if(ModelState.IsValid)
            {
                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    Items = CartActions.listItems,
                    Status = OrderStatus.ORDERED,
                };

                foreach (var orderItem in order.Items)
                {
                    orderItem.Order = order;
                    orderItem.OrderFK = order.Id;
                    _Menudb.OrderItems.Add(orderItem);
                    _Menudb.Entry(orderItem.MenuItem).State = EntityState.Unchanged;
                }


                if (_signInManager.IsSignedIn(User))
                {
                    order.IdCustomer = _userManager.GetUserAsync(User).Result.Id;
                    order.isGuestUser = false;
                }
                else
                {
                    model.Order = order;
                    model.OrderFK = order.Id;
                    _Menudb.CheckOut.Add(model);
                    order.isGuestUser = true;
                }
                foreach (OrderItem orderItem in order.Items)
                {
                    order.OrderTotal += orderItem.Quantity * (float)orderItem.MenuItem.Price * (float)1.15;
                }

                order.OrderAddress = model.Address;
                _Menudb.Orders.Add(order);

                _Menudb.SaveChanges();

                CartActions.listItems.Clear();
                return RedirectToAction("Index", "Home");
                //MAKE VIEW DON"T FORGET
                
            }
            return View("CheckoutPage");
        }

        public IActionResult CheckoutPage()
        {
            return View();
        }

        public IActionResult Orders()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                RedirectToAction("Error"); //todo make this work
            }
            var orders = _Menudb.Orders
                .OrderBy(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.IdCustomer == _userManager.GetUserAsync(User).Result.Id);
            return View(orders);
        }

        public IActionResult OrderDetails(int id)
        {
            var orders = _Menudb.Orders
                .OrderBy(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem);
            var order = orders.First(o => o.Id == id);
            //foreach(OrderItem orderItem in order.Items)
            //{
            //    order.OrderTotal += orderItem.Quantity * (float)orderItem.MenuItem.Price * (float)1.15;
            //}
            //todo check if it is current users order
            return View(order);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool IsReCaptchValid()
        {
        //https://www.c-sharpcorner.com/article/integration-of-google-recaptcha-in-websites/
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = _configuration["ExternalProviders:GoogleReCaptcha:SecretKey"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}
