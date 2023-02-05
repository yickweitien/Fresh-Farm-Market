using Fresh_Farm_Market.Model;
using Fresh_Farm_Market.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace Fresh_Farm_Market.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public Login LModel { get; set; }

        private readonly SignInManager<ApplicationUser> signInManager;
        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                /*                var identityResult = await signInManager.PasswordSignInAsync(LModel.Email, LModel.Password,
                               LModel.RememberMe, false);*/
                var identityResult = await signInManager.PasswordSignInAsync(LModel.Email, LModel.Password, LModel.RememberMe, lockoutOnFailure: true);
                if (identityResult.Succeeded)
                {
                    HttpContext.Session.SetString("username", "Welcome Member!");
                    return RedirectToPage("Index");
                }
                ModelState.AddModelError("", "Username or Password incorrect");

                if (identityResult.IsLockedOut)
                {
                    ModelState.AddModelError("", "The account is locked out");
                    return Page();
                }
            }
            return Page();
        }
    }
}

