using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Transactions
{
    public interface ITransationsService
    {
        List<Transaction> GetAllTransactionsById(int accountId, int skip, int take);

        void AddTransaction(Transaction transaction);
    }
}
