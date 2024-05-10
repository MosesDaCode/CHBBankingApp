using DataAccessLayer.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services.Transactions
{
    public class TransactionService : ITransationsService
    {
        private readonly BankAppDataContext _bankAppDataContext;

        public TransactionService(BankAppDataContext bankAppDataContext)
        {
            _bankAppDataContext = bankAppDataContext;
        }

        public List<DataAccessLayer.Models.Transaction> GetAllTransactionsById(int accountId, int skip, int take)
        {
            return _bankAppDataContext.Set<DataAccessLayer.Models.Transaction>()
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.Date)
                .Skip(skip)
                .Take(take)
                .ToList();
            
            //List<DataAccessLayer.Models.Transaction> transactions = _bankAppDataContext.Transactions
            //    .Where(t => t.AccountId == accountId)
            //    .OrderByDescending(t => t.Date)
            //    .Take(20)
            //    .ToList();

            //return transactions;
        }

        public void AddTransaction(DataAccessLayer.Models.Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            _bankAppDataContext.Transactions.Add(transaction);
            _bankAppDataContext.SaveChanges(); 
        }
    }
}
