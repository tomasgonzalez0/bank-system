namespace BankSystem.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public string Status { get; set; } 
        public int UserId { get; set; } 
    }

}
