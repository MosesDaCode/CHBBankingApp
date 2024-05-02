using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Customer;

namespace BankWeb.Pages.CustomerCard
{
    public class CustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerZipcode { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerMail { get; set; }

        public CustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void OnGet(int id)
        {
            var customer = _customerService.GetCustomer(id);

            CustomerId = customer.CustomerId;
            CustomerFirstName = customer.Givenname;
            CustomerLastName = customer.Surname;
            CustomerAdress = customer.Streetaddress;
            CustomerCity = customer.City;
            CustomerZipcode = customer.Zipcode;
            CustomerCountry = customer.Country;
            CustomerMail = customer.Emailaddress;
        }

        public IActionResult OnPostSoftDelete(int id)
        {
            _customerService.SoftDelete(id);
            return RedirectToPage("/Customers/Customers");
        }

    }
}
