using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VPWebSolutions.Models
{
    public class CheckoutModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = " First name cannot contain numbers")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "Last name cannot contain numbers")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

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
    }
}
