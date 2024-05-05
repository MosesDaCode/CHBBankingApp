using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Accounts;
using Services.Customer;

namespace BankWeb.Pages.Accounts
{
    public class CreateNewAccountModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly IHttpContextAccessor _contextAccessor;


        public CreateNewAccountModel(IAccountService accountService, ICustomerService customerService, IHttpContextAccessor contextAccessor)
        {
            _accountService = accountService;
            _customerService = customerService;
            _contextAccessor = contextAccessor;
        }

        [BindProperty]
        public Account newAccount { get; set; }
        public int CustomerId {  get; set; }
        public List<SelectListItem> Frequencies { get; set; }

        public void OnGet(int id)
        {
            var customer = _customerService.GetCustomer(id);
            CustomerId = customer.CustomerId;

            Frequencies = _accountService.GetFrequencies()
                .ConvertAll(c => new SelectListItem
                {
                    Text = c,
                    Value = c
                });

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _accountService.CreateAccount(newAccount.Frequency, newAccount.Balance);

            string returnUrl = _contextAccessor.HttpContext.Request.Headers["Referer"].ToString();

            return Redirect(returnUrl);
        }
    }
}
