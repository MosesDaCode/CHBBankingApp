using System.Runtime.InteropServices.Marshalling;

namespace BankWeb.ViewModels
{
    public class TransactionsViewModel
    {

        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public DateOnly TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}
