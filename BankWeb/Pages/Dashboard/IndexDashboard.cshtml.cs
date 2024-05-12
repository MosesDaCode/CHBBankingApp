using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankWeb.Pages.Dashboard
{
    [Authorize]
    public class IndexDashboardModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public IndexDashboardModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public string UserRole { get; set; }
        public IdentityUser CurrentUser { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            // Hämtar användarinformation asynkront
            CurrentUser = await _userManager.GetUserAsync(User);
            if (CurrentUser == null)
            {
                // Om ingen användare är inloggad kan du omdirigera till en inloggningsida eller visa ett felmeddelande
                return RedirectToPage("/Account/Login");  // Ersätt med korrekt URL om nödvändigt
            }

            // Hämtar användarroller asynkront
            var roles = await _userManager.GetRolesAsync(CurrentUser);
            UserRole = roles.FirstOrDefault();  // Anta att användaren bara har en roll för enkelhetens skull

            return Page();
        }
    }
}
