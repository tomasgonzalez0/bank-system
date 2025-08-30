using BankSystem.Domain.Entities;

namespace BankSystem.Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task AddAsync(Loan loan); 
        Task<Loan> GetByIdAsync(int id);
        Task SaveAsync();
        Task<List<Loan>> GetAllAsync();
    }
}
