using BankWeb.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Accounts;
namespace BankWeb.Pages.Accounts
{
    [BindProperties]
    public class DepositModel : PageModel
    {
        private readonly IAccountService _accountService;
        public DepositViewModel DepositData {  get; set; } 
        public DepositModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void OnGet()
        {
            DepositData = new DepositViewModel
            {
                DepositDate = DateTime.Now.AddHours(1)
            };
        }
        public IActionResult OnPost(int accountId)
        {
            if(DepositData.DepositDate < DateTime.Now)
            {
                ModelState.AddModelError("DepositData.DepositDate", "Cannot Deposit money in the past");
            }

            if(ModelState.IsValid)
            {
                var accountDb = _accountService.GetAccount(accountId);

                accountDb.Balance += DepositData.Amount;
                _accountService.Update(accountDb);

                return RedirectToPage("./IndexAccount");
            }
            return Page();
        }
    }
}
