using Fresh_Farm_Market.Model;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Fresh_Farm_Market.Pages
{
    public class IndexModel : PageModel
    {

        private UserManager<ApplicationUser> userManager { get; }
        private SignInManager<ApplicationUser> signInManager { get; }

        private IWebHostEnvironment _environment;
        public string Username { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment environment, ILogger<IndexModel> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _environment = environment;
            _logger = logger;
        }

        public string User_Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public string DeliveryAddress { get; set; }

        public string Photo { get; set; }

        public string CreditCard { get; set; }

        public string AboutMe { get; set; }

        public void OnGet()
        {
            if (signInManager.IsSignedIn(User))
            {
                var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                var protector = dataProtectionProvider.CreateProtector("MySecretKey");


                User_Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Email = userManager.FindByIdAsync(User_Id).Result.Email;
                Gender = userManager.FindByIdAsync(User_Id).Result.Gender;
                PhoneNumber = userManager.FindByIdAsync(User_Id).Result.PhoneNumber;
                DeliveryAddress = userManager.FindByIdAsync(User_Id).Result.DeliveryAddress;
                Photo = userManager.FindByIdAsync(User_Id).Result.Photo;
                CreditCard = protector.Unprotect(userManager.FindByIdAsync(User_Id).Result.CreditCard);
                AboutMe = userManager.FindByIdAsync(User_Id).Result.AboutMe;
                FullName = userManager.FindByIdAsync(User_Id).Result.FullName;
                Username = HttpContext.Session.GetString("username");
            }
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();
            return RedirectToPage("Index");


        }
    }
}