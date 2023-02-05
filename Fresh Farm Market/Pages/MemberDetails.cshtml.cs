using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fresh_Farm_Market.Model;
using Fresh_Farm_Market.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Fresh_Farm_Market.Pages
{
    public class MemberDetailsModel : PageModel
    {

        /*        private UserManager<ApplicationUser> userManager { get; }
                private SignInManager<ApplicationUser> signInManager { get; }

                private IWebHostEnvironment _environment;

                private readonly ILogger<IndexModel> _logger;
                public MemberDetailsModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment environment)
                {
                    this.userManager = userManager;
                    this.signInManager = signInManager;
                    _environment = environment;
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
                    User_Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Email = userManager.FindByIdAsync(User_Id).Result.Email;
                    Gender = userManager.FindByIdAsync(User_Id).Result.Gender;
                    PhoneNumber = userManager.FindByIdAsync(User_Id).Result.PhoneNumber;
                    DeliveryAddress = userManager.FindByIdAsync(User_Id).Result.DeliveryAddress;
                    Photo = userManager.FindByIdAsync(User_Id).Result.Photo;
                    CreditCard = userManager.FindByIdAsync(User_Id).Result.CreditCard;
                    AboutMe = userManager.FindByIdAsync(User_Id).Result.AboutMe;
                    FullName = userManager.FindByIdAsync(User_Id).Result.FullName;

                }

            }*/
    }
}
