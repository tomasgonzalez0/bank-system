using BankSystem.Domain.DTOs;
using BankSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost("request")]
        public async Task<IActionResult> RequestLoan([FromBody] LoanRequestDto loanRequest)
        {
            var loan = await _loanService.RequestLoanAsync(loanRequest);
            if (loan == null)
                return BadRequest("Solicitud de préstamo inválida.");

            return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, loan);
        }

        [HttpPut("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveLoan(int id)
        {
            var loan = await _loanService.ApproveLoanAsync(id);
            if (loan == null)
                return NotFound();

            return Ok(loan);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById(int id)
        {
            var loan = await _loanService.GetLoanByIdAsync(id);
            if (loan == null)
                return NotFound();

            return Ok(loan);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllLoans()
        {
            var loans = await _loanService.GetAllLoansAsync();
            return Ok(loans);
        }

    }

}
