using DataAccessLayer.Models;

namespace BankWeb.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers(string sortColumn, string sortOrder, int pageNo, string searchBox);
    }
}
    