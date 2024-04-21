using System.ComponentModel.DataAnnotations;

namespace BankWeb.ViewModels
{
    public class CustomerViewModel
    {
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required] 
        public string LastName { get; set; }

        [StringLength(100)]
        [Required]
        public string StreetAdress { get; set; }

        [StringLength(10)]
        [Required]
        public string PostalCode { get; set; }

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [StringLength(50)]
        [Required]
        public string Country { get; set; }

        [StringLength(2)]
        public string CountryCode { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateOnly Birthday { get; set; }

        [StringLength(150)]
        [EmailAddress]
        public string? Emailaddress { get; set; }
    }
}
