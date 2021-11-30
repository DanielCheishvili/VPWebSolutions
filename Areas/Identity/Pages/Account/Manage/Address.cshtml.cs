using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Areas.Identity.Pages.Account.Manage
{
    public partial class AddressModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AddressModel(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "New Address")]
            public string NewAddress { get; set; }

            [Required]
                //Taken from https://blog.platformular.com/2012/03/03/how-to-validate-canada-postal-code-in-c/
            [RegularExpression("^[ABCEGHJ-NPRSTVXYabceghj-nprstvxy]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Zabceghj-nprstv-z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Zabceghj-nprstv-z]{1}[0-9]{1}$", ErrorMessage = "Must be in proper format with capital letters (X2X 2X2)")]
            [Display(Name = "New Postal Code")]
            public string NewPostalCode { get; set; }

            [Required]
            [Display(Name = "New City")]
            public string NewCity { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var address = user.Address;
            var city = user.City;
            var postalCode = user.PostalCode;

            Input = new InputModel
            {
                NewAddress = address,
                NewCity = city,
                NewPostalCode = postalCode,
            };
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
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var address = user.Address;
            var city = user.City;
            var postalCode = user.PostalCode;

            StatusMessage = "Your address is unchanged.";

            if (Input.NewAddress != address)
            {
                user.Address = Input.NewAddress;
                await _userManager.UpdateAsync(user);
                StatusMessage = "Your address is updated.";
            }
            if (Input.NewCity != city)
            {
                user.City = Input.NewCity;
                await _userManager.UpdateAsync(user);
                StatusMessage = "Your address is updated.";
            }
            if (Input.NewPostalCode != postalCode)
            {
                user.PostalCode = Input.NewPostalCode;
                await _userManager.UpdateAsync(user);
                StatusMessage = "Your address is updated.";
            }

            return RedirectToPage();
        }
    }
}
