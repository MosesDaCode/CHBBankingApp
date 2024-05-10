using BankWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Accounts;
using Services.Transactions;

namespace BankWeb.Pages.Accounts.Transactions
{
    [BindProperties]
    public class WithdrawModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly ITransationsService _transactionsService;

        public WithdrawViewModel WithdrawData { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }

        public WithdrawModel(IAccountService accountService, ITransationsService transationsService)
        {
            _accountService = accountService;
            _transactionsService = transationsService;

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

                var withdraw = new DataAccessLayer.Models.Transaction
                {
                    AccountId = accountId,
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Type = "Credit",
                    Operation = "Withdrawl",
                    Amount = WithdrawData.Amount,
                    Balance = accountDb.Balance,
                    Symbol = "Currency Symbol",
                    Bank = "CHB"
                };
                _transactionsService.WithdrawMoney(withdraw);
                return RedirectToPage("/Accounts/Transactions/Transaction", new {accountId = AccountId, customerId = CustomerId});
            }
            return Page();


        }
    }
}
