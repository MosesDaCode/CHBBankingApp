using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace Services.Customer
{
    public interface ICustomerService
    {
        public IEnumerable<DataAccessLayer.Models.Customer> GetCustomers();
        int SaveNewCustomer(DataAccessLayer.Models.Customer customer);

        void Update(DataAccessLayer.Models.Customer customer);
        void SoftDelete(int customerId);

        DataAccessLayer.Models.Customer GetCustomer(int customerId);
    }
}
