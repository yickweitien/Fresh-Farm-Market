using Fresh_Farm_Market.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fresh_Farm_Market.Pages
{
    public class LogoutModel : PageModel
    {

        private readonly SignInManager<ApplicationUser> signInManager;
        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();
            return RedirectToPage("Login");
        }

        public async Task<IActionResult> OnPostDontLogoutAsync()
        {
            return RedirectToPage("Index");

        }
    }
}
