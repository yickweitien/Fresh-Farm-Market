using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Fresh_Farm_Market.ViewModels
{
    public class Register
    {

        [Required]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [Required, MaxLength(16)]
        [DataType(DataType.Text)]
        public string CreditCard { get; set; }

        [Required, MaxLength(1)]
        public string Gender { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(12, ErrorMessage = "Enter at least a 12 characters password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{12,}$",ErrorMessage = "Passwords must be at least 12 characters long and contain at least an uppercase letter, lower case letter, digit and a symbol")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(50)]
        public string? Photo { get; set; }

        [Required]
        public string AboutMe { get; set; }




    }
}
