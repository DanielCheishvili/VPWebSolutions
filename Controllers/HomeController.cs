using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
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
using VPWebSolutions.Models;

namespace VPWebSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        //Instantiating the IEmailSender interface using Dependency Injection
        private readonly PizzaBrosContext _db;


        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, IConfiguration configuration, PizzaBrosContext context)
        {
            _logger = logger;
            _emailSender = emailSender;
            _configuration = configuration;
            _db = context;
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
                _db.Contacts.Add(contact);
                _db.SaveChanges();
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
            return View();
        }

        [HttpGet("Cart")]
        public IActionResult Cart(){
            return View();
        }

        //[HttpGet("Register")]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        [HttpPost("Register")]
        public IActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid && IsReCaptchValid())
            {
                _db.Database.EnsureCreated();

                _db.CustomerAccounts.Add(
                    new CustomerAccount()
                    {
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        Email = register.Email,
                        Password = register.Password,
                        Address = register.Address,
                        City = register.City,
                        Province = register.Province,
                        PostalCode = register.PostalCode,
                        Phone = register.Phone
                    });
                _db.SaveChanges();
                return View("RegisterSuccess");
            }
            return View();
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
