using BankWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Accounts;

namespace BankWeb.Pages.Accounts.Transactions
{
    [BindProperties]
    public class WithdrawModel : PageModel
    {
        private readonly IAccountService _accountService;
        public WithdrawViewModel WithdrawData { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }

        public WithdrawModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public void OnGet(int accountId, int customerId)
        {
            AccountId = accountId;
            CustomerId = customerId;
            var account = _accountService.GetAccount(accountId);
            if (account != null)
            {
                WithdrawData = new WithdrawViewModel
                {
                    Balance = account.Balance
                };
            }
        }

        public IActionResult OnPost(int accountId)
        {
            var accountDb = _accountService.GetAccount(accountId);
            WithdrawData.Balance = accountDb.Balance;
            if (accountDb.Balance < WithdrawData.Amount)
            {
                ModelState.AddModelError("WithdrawData.Amount", "You dont have that much money");
            }

            if (ModelState.IsValid)
            {
                accountDb.Balance -= WithdrawData.Amount;
                _accountService.Update(accountDb);
                return RedirectToPage("./IndexAccount");
            }
            return Page();


        }
    }
}
