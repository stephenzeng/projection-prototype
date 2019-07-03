using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeng.Prototypes.Projection.Domain;
using Zeng.Prototypes.Projection.Events;

namespace Zeng.Prototypes.Projection.Projections
{
    public class LoanProjection : Projection, IProjection
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public LoanProjection(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task When(NewLoanCreatedEvent e)
        {
            var loan = _mapper.Map<LoanEntity>(e);
            _dbContext.Loans.Add(loan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task When(LoanLedgerEvent e)
        {
            var loan = await _dbContext.Loans.FirstOrDefaultAsync(l => l.Id == e.AggregateId);
            if (loan == null) throw new InvalidOperationException($"Loan {e.AggregateId} does not exist");

            loan.Balance += e.Amount;
            loan.LastChanged = e.TransactionDate;

            var loanTransaction = _mapper.Map<LoanTransactionEntity>(e);
            _dbContext.LoanTransactions.Add(loanTransaction);

            await _dbContext.SaveChangesAsync();
        }
    }
}