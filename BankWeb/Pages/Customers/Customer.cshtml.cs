using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankWeb.Pages.Customers
{   
    public class CustomerModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerZipcode { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerMail { get; set; }

        public CustomerModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int id)
        {


            var customer = _dbContext.Customers
                .First(c => c.CustomerId == id);

            CustomerFirstName = customer.Givenname;
            CustomerLastName = customer.Surname;
            CustomerAdress = customer.Streetaddress;
            CustomerCity = customer.City;
            CustomerZipcode = customer.Zipcode;
            CustomerCountry = customer.Country;
            CustomerMail = customer.Emailaddress;



            //CustomerFirstName = _dbContext.Customers
            //    .First(f => f.CustomerId == id).Givenname;
            //CustomerLastName = _dbContext.Customers
            //    .First(l => l.CustomerId == id).Surname;
            //CustomerLastName = _dbContext.Customers
            //    .First(a => a.CustomerId == id).Streetaddress;
            //CustomerLastName = _dbContext.Customers
            //    .First(c => c.CustomerId == id).City;
            //CustomerLastName = _dbContext.Customers
            //    .First(z => z.CustomerId == id).Zipcode;
            //CustomerLastName = _dbContext.Customers
            //    .First(c => c.CustomerId == id).Country;
            //CustomerLastName = _dbContext.Customers
            //    .First(m => m.CustomerId == id).Emailaddress;
        }
    }
}
