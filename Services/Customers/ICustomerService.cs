using DataAccessLayer.Models;

namespace Services.Customers
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers(string sortColumn, string sortOrder, int pageNo, string searchBox);
    }
}
