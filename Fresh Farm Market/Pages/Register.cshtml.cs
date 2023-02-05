using Fresh_Farm_Market.ViewModels;
using Fresh_Farm_Market.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace Fresh_Farm_Market.Pages
{

    //Initialize the build-in ASP.NET Identity
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> userManager { get; }
        private SignInManager<ApplicationUser> signInManager { get; }

        private IWebHostEnvironment _environment;

        [BindProperty]
        public Register RModel { get; set; }
        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _environment = environment;
        }
        public void OnGet()
        {
        }

        //Save data into the database
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                var protector = dataProtectionProvider.CreateProtector("MySecretKey");



                var user = new ApplicationUser()
                {
                    UserName = RModel.Email,
                    FullName = RModel.FullName,
                    CreditCard = protector.Protect(RModel.CreditCard),
                    Gender = RModel.Gender,
                    PhoneNumber = RModel.PhoneNumber,
                    DeliveryAddress = RModel.DeliveryAddress,
                    Email = RModel.Email,
                    Photo = RModel.Photo,
                    AboutMe = RModel.AboutMe

                };

                if (Upload != null)
                {
                    var imageFile = Guid.NewGuid() + Path.GetExtension(Upload.FileName);
                    var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\uploads", imageFile);
                    using var fileStream = new FileStream(file, FileMode.Create);
                    await Upload.CopyToAsync(fileStream);
                    RModel.Photo = "/uploads/" + imageFile;
                }

                var result = await userManager.CreateAsync(user, RModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    HttpContext.Session.SetString("username", "Welcome Member!");
                    return RedirectToPage("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }

        [BindProperty]
        public IFormFile? Upload { get; set; }
    }
}
