namespace BankSystem.Domain.DTOs
{
    public class LoanRequestDto
    {
        public decimal Amount { get; set; } 
        public int TermMonths { get; set; }
    }
}
