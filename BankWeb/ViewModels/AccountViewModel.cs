namespace BankWeb.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public string Frequency { get; set; }
        public DateOnly Created { get; set; }
    }
}
