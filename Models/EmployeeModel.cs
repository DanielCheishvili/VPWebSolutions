using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPWebSolutions.Models
{
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "First Name must have at least 2 characters long.")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "First Name cannot contain numbers.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "Last Name cannot contain numbers.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [RegularExpression("[a-zA-z][0-9][a-zA-z] ?[0-9][a-zA-z][0-9]", ErrorMessage = "Please enter a valid canadian postal code (X1X 1X1)")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public List<ManageUserRolesViewModel> Roles { get; set; }
    }
}
