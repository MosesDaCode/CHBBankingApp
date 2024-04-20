using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Accounts
{
    public interface IAccountService
    {
        List<Account> GetAccounts();
        void Update(Account account);
        Account GetAccount(int id);
    }
}
