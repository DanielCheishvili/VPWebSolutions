using System.ComponentModel.DataAnnotations;

namespace VPWebSolutions.Models
{
    public class RegisterModel
    {
        [Required]
        [MinLength(2, ErrorMessage ="First Name must have at least 2 characters long.")]
        [RegularExpression("^[^0-9]+$", ErrorMessage ="First Name cannot contain numbers.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(1)]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "Last Name cannot contain numbers.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Key]
        [DataType(DataType.EmailAddress)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage ="Password must be at least 8 characters")]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required]
        //Taken from https://blog.platformular.com/2012/03/03/how-to-validate-canada-postal-code-in-c/
        [RegularExpression("^[ABCEGHJ-NPRSTVXYabceghj-nprstvxy]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Zabceghj-nprstv-z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Zabceghj-nprstv-z]{1}[0-9]{1}$", ErrorMessage ="Must be in proper format with capital letters (X2X 2X2)")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
                
    }
}
