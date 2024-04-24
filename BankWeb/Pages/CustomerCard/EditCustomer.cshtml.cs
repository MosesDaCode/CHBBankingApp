using BankWeb.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Customer;

namespace BankWeb.Pages.CustomerCard
{ 
    [BindProperties]
    public class EditCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public EditCustomerViewModel CustomerVm { get; set; }
        public EditCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void OnGet(int id)
        {
            var customerDb = _customerService.GetCustomer(id);
            if (customerDb == null)
            {
                 RedirectToPage("/NotFound");
                return;
            }

            CustomerVm = new EditCustomerViewModel
             {
                Id = customerDb.CustomerId,
                FirstName = customerDb.Givenname,
                LastName = customerDb.Surname,
                Emailaddress = customerDb.Emailaddress,
                StreetAdress = customerDb.Streetaddress,
                PostalCode = customerDb.Zipcode,
                City = customerDb.City,
                Country = customerDb.Country,
                CountryCode = customerDb.CountryCode,
                Birthday = customerDb.Birthday
             };


        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var custDb = _customerService.GetCustomer(id);

                custDb.CustomerId = id;
                custDb.Givenname = CustomerVm.FirstName;
                custDb.Surname = CustomerVm.LastName;
                custDb.Emailaddress = CustomerVm.Emailaddress;
                custDb.Streetaddress = CustomerVm.StreetAdress;
                custDb.Zipcode = CustomerVm.PostalCode;
                custDb.City = CustomerVm.City;
                custDb.CountryCode = CustomerVm.CountryCode;
                custDb.Birthday = CustomerVm.Birthday;

                _customerService.Update(custDb);

                return RedirectToPage("/CustomerCard/Customer", new {id = custDb.CustomerId});
            }

            return Page();
        }

        

    }
}
