using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using Services.Customer;
using BankWeb.ViewModels;

namespace BankWeb.Pages.CustomerCard
{
    [BindProperties]
    public class NewCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public NewCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
         public NewCustomerViewModel CustomerVm { get; set; }        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var cust = new Customer
                {
                    CustomerId = CustomerVm.id,
                    Givenname = CustomerVm.FirstName,
                    Surname = CustomerVm.LastName,
                    Streetaddress = CustomerVm.StreetAdress,
                    Zipcode = CustomerVm.PostalCode,
                    City = CustomerVm.City,
                    Country = CustomerVm.Country,
                    CountryCode = CustomerVm.CountryCode,
                    Emailaddress = CustomerVm.Emailaddress,
                    Birthday = CustomerVm.Birthday,
                    Gender = CustomerVm.Gender
                };
                _customerService.SaveNewCustomer(cust);
                return RedirectToPage("/Customers/Customers");
            }
            return Page();
        }
    }
}
