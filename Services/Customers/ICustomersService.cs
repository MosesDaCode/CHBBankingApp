using DataAccessLayer.Models;
namespace Services.Customers
{
    public interface ICustomersService
    {
        List<DataAccessLayer.Models.Customer> GetCustomers(string sortColumn, string sortOrder, int pageNo, string searchBox);
    }
}
