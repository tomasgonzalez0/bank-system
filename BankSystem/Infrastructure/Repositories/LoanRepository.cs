using BankSystem.Domain.Entities;
using BankSystem.Domain.Interfaces;
using BankSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Loan>> GetAllAsync() 
        {
            return await _context.Loans.ToListAsync();
        }
    }
}
