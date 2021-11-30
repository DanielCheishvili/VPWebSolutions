using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPizzaRepository _repository;

        public ProfileController(ILogger<ProfileController> logger,
        SignInManager<ApplicationUser> signinManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IPizzaRepository repository)
        {
            _logger = logger;
            _signinManager = signinManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _repository = repository;
        }

        [HttpGet("Profile")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            List<String> userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            var userdata = _repository.GetUserById(Convert.ToInt32(user.Id));
            if (userdata == null)
            {
                // Create UserData on first use
                userdata = new UserData
                {
                    IdentityUserId = user.Id,
                    PrefferedAddress = "Unknown",
                    Orders = new List<Order>()
                };
            }

            var model = new ShowProfileViewModel
            {
                UserDataId = userdata.UserDataId,
                Address = userdata.PrefferedAddress,
                Orders = userdata.Orders,
                Email = user.Email,
                Roles = _roleManager.Roles.Where(x => x.Name == user.UserName).ToList()
            };

            return View(model);
        }
    }
}
