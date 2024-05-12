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
            // H�mtar anv�ndarinformation asynkront
            CurrentUser = await _userManager.GetUserAsync(User);
            if (CurrentUser == null)
            {
                // Om ingen anv�ndare �r inloggad kan du omdirigera till en inloggningsida eller visa ett felmeddelande
                return RedirectToPage("/Account/Login");  // Ers�tt med korrekt URL om n�dv�ndigt
            }

            // H�mtar anv�ndarroller asynkront
            var roles = await _userManager.GetRolesAsync(CurrentUser);
            UserRole = roles.FirstOrDefault();  // Anta att anv�ndaren bara har en roll f�r enkelhetens skull

            return Page();
        }
    }
}
