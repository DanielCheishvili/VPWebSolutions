using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VPWebSolutions.Data;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Areas.Identity.Pages.Account.Manage
{
    public partial class OrderModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BusinessDbContext _businessDb;


        public OrderModel(
            UserManager<ApplicationUser> userManager, BusinessDbContext businessDb)
        {
            _userManager = userManager;
            _businessDb = businessDb;
        }

        public List<Order> Orders { get; set; } = new List<Order>();

        [TempData]
        public string StatusMessage { get; set; }


        private async Task LoadAsync(ApplicationUser user)
        {
            var findUser = _businessDb.UserDatas.Where(u => u.IdentityUserId == user.Id).ToList();
            Orders = findUser[0].Orders;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeAddressAsync()
        {
            return RedirectToPage();
        }
    }
}
