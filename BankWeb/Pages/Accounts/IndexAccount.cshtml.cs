using BankWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Accounts;
using System.Linq;

namespace BankWeb.Pages.Accounts
{
    public class IndexAccountModel : PageModel
    {
        private readonly IAccountService _accountService;
        public IndexAccountModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public List<AccountViewModel> Accounts { get; set; }
        public void OnGet()
        {
            Accounts = _accountService.GetAccounts()
                .Select(a => new AccountViewModel
                {
                    Id = a.AccountId,
                    Balance = a.Balance
                }).ToList();
        }
    }
}
