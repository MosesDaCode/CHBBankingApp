using BankWeb.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.Customer;
using Services.Transactions;
using System.Runtime.CompilerServices;

namespace BankWeb.Pages.Accounts.Transactions
{
    public class TransactionModel : PageModel
    {
        private readonly ITransationsService _transactionsService;
        private readonly ICustomerService _customerService;
        private const int PageSize = 20;

        public TransactionModel(ITransationsService transationsService, ICustomerService customerService)
        {
            _transactionsService = transationsService;
            _customerService = customerService;
        }
        public List<Transaction> Transactions { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public void OnGet(int accountId , int customerId)
        {
            AccountId = accountId;
            CustomerId = customerId;
            Transactions = _transactionsService.GetAllTransactionsById(accountId, 0, PageSize)
                .Select(t => new Transaction
                {
                    AccountId = t.AccountId,
                    Date = t.Date,
                    Amount = t.Amount,
                    Balance = t.Balance,
                }).ToList();

            
        }

        public IActionResult OnGetShowMore(int accountId, int pageIndex)
        {
            var transactions = _transactionsService.GetAllTransactionsById(accountId, pageIndex * PageSize, PageSize)
                .Select(t => new
                {
                    AccountId = t.AccountId,
                    Date = t.Date,
                    Amount = t.Amount,
                    Balance = t.Balance
                }).ToList();

            if (!transactions.Any())
            {
                return new JsonResult(new { error = "No transactions found" });
            }

            return new JsonResult(transactions); return new JsonResult(transactions);
        }


    }
}
