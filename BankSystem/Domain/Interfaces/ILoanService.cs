using BankSystem.Domain.DTOs;
using BankSystem.Domain.Entities;

namespace BankSystem.Domain.Interfaces
{
    public interface ILoanService
    {
        Task<Loan> RequestLoanAsync(LoanRequestDto loanRequest);
        Task<Loan> ApproveLoanAsync(int loanId);
        Task<Loan> GetLoanByIdAsync(int id);
        Task<List<Loan>> GetAllLoansAsync();
    }
}
