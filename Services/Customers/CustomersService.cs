using DataAccessLayer.Models;

namespace Services.Customers
{
    public class CustomersService : ICustomersService
    {
        private readonly BankAppDataContext _dbContext;

        public CustomersService(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DataAccessLayer.Models.Customer> GetCustomers(string sortColumn, string sortOrder, int pageNo, string searchBox, bool isActive = true)
        {
            var query = _dbContext.Customers
                .Where(c => c.IsActive == isActive)
                .AsQueryable();




            if (!string.IsNullOrEmpty(searchBox))
            {
                query = query
                    .Where(s => s.Givenname.Contains(searchBox) ||
                    s.City.Contains(searchBox) || s.Country.Contains(searchBox));
            }
            var firstItemIndex = (pageNo - 1) * 10;
            if (firstItemIndex < 0)
            {
                firstItemIndex = 0;
            }

            query = query.Skip(firstItemIndex);
            query = query.Take(10);

            if (sortColumn == "Name")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.Givenname);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.Givenname);

            if (sortColumn == "Country")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.Country);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.Country);

            if (sortColumn == "City")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.City);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.City);

            return query.ToList();
        }

    }
}
