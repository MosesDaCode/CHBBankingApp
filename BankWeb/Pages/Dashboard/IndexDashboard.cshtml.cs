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
        public IdentityUser CurrentUser { get; set; }
        public void OnGet()
        {
        }
    }
}
