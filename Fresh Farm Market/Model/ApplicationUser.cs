using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Farm_Market.Model
{
    public class ApplicationUser : IdentityUser
    {
        
        public string FullName { get; set; }

        
        public string CreditCard { get; set; }

        public string Gender { get; set; }

        
        public string DeliveryAddress { get; set;}

       
        public string PhoneNumber { get; set; }

        public string? Photo { get; set; }

        public string AboutMe { get; set; }
    }
}
