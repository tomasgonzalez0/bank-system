using BankSystem.Domain.DTOs;
using BankSystem.Domain.Entities;
using BankSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BankSystem.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository; 

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Loan> RequestLoanAsync(LoanRequestDto loanRequest)
        {
            var loan = new Loan
            {
                Amount = loanRequest.Amount,
                TermMonths = loanRequest.TermMonths,
                Status = "Pending" 
            };

            await _loanRepository.AddAsync(loan);
            return loan;
        }

        public async Task<Loan> ApproveLoanAsync(int loanId)
        {
            var loan = await _loanRepository.GetByIdAsync(loanId);
            if (loan == null)
            {
                return null; 
            }

            loan.Status = "Approved"; 
            await _loanRepository.SaveAsync(); 
            return loan;
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            return await _loanRepository.GetByIdAsync(id);
        }

        public async Task<List<Loan>> GetAllLoansAsync()
        {
            return await _loanRepository.GetAllAsync();
        }


    }
}
