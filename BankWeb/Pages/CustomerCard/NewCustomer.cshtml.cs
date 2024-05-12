using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using Services.Customer;
using BankWeb.ViewModels;
using Services.Countries;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Gender;

namespace BankWeb.Pages.CustomerCard
{
    [BindProperties]
    public class NewCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly ICountriesService _countriesService;
        private readonly IGenderService _genderService;

        public NewCustomerModel(ICustomerService customerService, ICountriesService countriesService, IGenderService genderService)
        {
            _customerService = customerService;
            _countriesService = countriesService;
            _genderService = genderService;
        }
        public NewCustomerViewModel CustomerVm { get; set; }  
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> TwoGenders { get; set; }

        public void OnGet()
        {
            Countries = _countriesService.GetAllCountries()
                .ConvertAll(c => new SelectListItem
                {
                    Text = c,
                    Value = c
                });

            TwoGenders = _genderService.GetBothGenders()
                .ConvertAll(g => new SelectListItem
                {
                    Text = g,
                    Value = g
                });
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var cust = new DataAccessLayer.Models.Customer
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

                TempData["SuccessMessage"] = "New customer created successfully!";
                return RedirectToPage("/Customers/Customers");
            }
            return Page();
        }
    }
}
