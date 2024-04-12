using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankWeb.ViewModels;
using BankWeb.Services;

namespace BankWeb.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public CustomersModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public List<CustomersViewModel> Customers { get; set; }
        public int CurrentPage { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int CustomerId { get; set; }
        public string SearchBox { get; set; }
        public void OnGet(int customerId, string sortColumn, string sortOrder, int pageNo, string searchBox)
        {
            CurrentPage = pageNo == 0 ? 1 : pageNo;
            SortColumn = sortColumn;
            SortOrder = sortOrder;
            SearchBox = searchBox;

            Customers = _customerService.GetCustomers(sortColumn, sortOrder, pageNo, searchBox)
            .Select(s => new CustomersViewModel
            {
                Id = s.CustomerId,
                Name = s.Givenname,
                City = s.City,
                Country = s.Country
            }).ToList();


        }
    }
}
