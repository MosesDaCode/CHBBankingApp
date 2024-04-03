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
        public void OnGet(string sortColumn, string sortOrder)
        {
            Customers = _customerService.GetCustomers(sortColumn, sortOrder)
            .Take(10)
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
