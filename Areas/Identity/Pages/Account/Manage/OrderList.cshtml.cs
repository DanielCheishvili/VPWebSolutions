using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Areas.Identity.Pages.Account.Manage
{
    public partial class OrderModel : PageModel
    {
        private readonly UserManager<UserData> _userManager;

        public OrderModel(
            UserManager<UserData> userManager)
        {
            _userManager = userManager;
        }

        public List<Order> Orders { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        private async Task LoadAsync(UserData user)
        {
            Orders = user.Orders;
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
