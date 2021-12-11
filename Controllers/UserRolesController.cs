using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Data.Enums;
using VPWebSolutions.Models;

namespace VPWebSolutions.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> GetEmployees()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserIdentityId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRoles(user);

                bool addToModel = true;
                foreach (IdentityRole role in thisViewModel.Roles)
                {
                    if(role.Name == Roles.Admin.ToString() || role.Name == Roles.Manager.ToString() || role.Name == Roles.Customer.ToString())
                    {
                        addToModel = false;
                        break;
                    }
                }
                if (addToModel)
                {
                    userRolesViewModel.Add(thisViewModel);
                }
            }
            return View("Index", userRolesViewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetEmployeesAndManagers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserIdentityId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRoles(user);

                bool addToModel = true;
                foreach (IdentityRole role in thisViewModel.Roles)
                {
                    if (role.Name == Roles.Admin.ToString() || role.Name == Roles.Customer.ToString())
                    {
                        addToModel = false;
                        break;
                    }
                }
                if (addToModel)
                {
                    userRolesViewModel.Add(thisViewModel);
                }
            }
            return View("Index", userRolesViewModel);
        }

        private async Task<List<IdentityRole>> GetUserRoles(ApplicationUser user)
        {
            List<string> roleStrings = (List<string>)await _userManager.GetRolesAsync(user);
            List<IdentityRole> identityRoles = new List<IdentityRole>();

            foreach (string role in roleStrings)
            {
                identityRoles.Add(new IdentityRole(role));
            }
            return identityRoles;
        }

        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageAdmin(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            ViewBag.UserName = user.UserName;
            ViewBag.Refer = Request.Headers["Referer"].ToString();
            
            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                if (userRolesViewModel.RoleName == "Admin" || userRolesViewModel.RoleName == "Customer")
                {
                    continue;
                }
                model.Add(userRolesViewModel);
            }
            return View("Manage", model);
        }

        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> ManageManager(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            ViewBag.UserName = user.UserName;
            ViewBag.Refer = Request.Headers["Referer"].ToString();

            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                if(userRolesViewModel.RoleName == "Admin" || userRolesViewModel.RoleName == "Manager" || userRolesViewModel.RoleName == "Customer")
                {
                    continue;
                }
                model.Add(userRolesViewModel);
            }
            return View("Manage", model);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId, string returnUrl)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Redirect(returnUrl);
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return Redirect(returnUrl);
        }

        [Authorize(Roles = "Manager, Admin")]
        public IActionResult CreateEmployee()
        {
            var model = new EmployeeModel();
            model.Roles = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                userRolesViewModel.Selected = false;

                if(userRolesViewModel.RoleName == "Admin" || userRolesViewModel.RoleName == "Manager" || userRolesViewModel.RoleName == "Customer")
                {
                    continue;
                }
                model.Roles.Add(userRolesViewModel);
            }

            ViewBag.refer = "ManageManager";

            return View("Create", model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateEmployeeAndManager()
        {
            var model = new EmployeeModel();
            model.Roles = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                userRolesViewModel.Selected = false;

                if (userRolesViewModel.RoleName == "Admin" || userRolesViewModel.RoleName == "Customer")
                {
                    continue;
                }
                model.Roles.Add(userRolesViewModel);
            }

            ViewBag.refer = "ManageAdmin";

            return View("Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel employee, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    UserName = employee.Email, 
                    Email = employee.Email, 
                    PhoneNumber = employee.Phone, 
                    Address = employee.Address, 
                    PostalCode = employee.PostalCode, 
                    City = employee.City };
                var result = await _userManager.CreateAsync(user, employee.Password);
                await _userManager.AddToRolesAsync(user, employee.Roles.Where(x => x.Selected).Select(y => y.RoleName));
            }
            return RedirectToAction(actionName:"Index", controllerName:"Home");
        }
    }
}
