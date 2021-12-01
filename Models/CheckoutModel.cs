using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data.Entities;

namespace VPWebSolutions.Models
{
    public class CheckoutModel
    {
        public int Id { get; set; }

        public Order Order { get; set; }
        public int OrderFK { get; set; }

        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = " First name cannot contain numbers")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "Last name cannot contain numbers")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [RegularExpression("[a-zA-z][0-9][a-zA-z] ?[0-9][a-zA-z][0-9]", ErrorMessage = "Please enter a valid canadian postal code (X1X 1X1)")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Email must be at least 2 characters long")]
        [MaxLength(30, ErrorMessage = "Email cannot exceed 50 characters")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression("^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$", ErrorMessage = "Please enter a valid card number. (XXXX-XXXX-XXXX-XXXX)")]
        [Display(Name= "Card number")]
        public int CreditNumber { get; set; }

        [Required]
        [Display(Name ="Expiration Month")]
        public string Month { get; set; }

        [Required]
        [Display(Name = "Expiration Year")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Security Code")]
        [RegularExpression("^[0-9]{3}$", ErrorMessage = "Please enter a valid CVV (XXX)")]
        public int SecurityCode { get; set; }

 
    }
}
