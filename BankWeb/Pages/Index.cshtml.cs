using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;

namespace BankWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BankAppDataContext _dbContext;
        public int TotalCustomers { get; set; }
        public int TotalAccounts { get; set; }
        public decimal TotalSum { get; set; }

        public IndexModel(ILogger<IndexModel> logger, BankAppDataContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;

        }
        public void OnGet()
        {
            TotalCustomers = _dbContext.Customers.Count();
            TotalAccounts = _dbContext.Accounts.Count();
            TotalSum = _dbContext.Transactions.Sum(t => t.Amount);
        }
    }
}
