using System;
using System.Threading.Tasks;
using AutoMapper;
using Zeng.Prototypes.Projection.Domain;
using Zeng.Prototypes.Projection.Events;
using Zeng.Prototypes.Projection.Repositories;

namespace Zeng.Prototypes.Projection.Projections
{
    public class LoanProjection : Projection, IProjection
    {
        private readonly IRepository<LoanEntity> _loanRepository;
        private readonly IRepository<LoanTransactionEntity> _loanTransactionRepository;
        private readonly IMapper _mapper;

        public LoanProjection(IRepository<LoanEntity> loanRepository, IRepository<LoanTransactionEntity> loanTransactionRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _loanTransactionRepository = loanTransactionRepository;
            _mapper = mapper;
        }
        
        public async Task When(NewLoanCreatedEvent e)
        {
            var loan = _mapper.Map<LoanEntity>(e);
            _loanRepository.Add(loan);
            await _loanRepository.SaveChangesAsync();
        }

        public async Task When(LoanLedgerEvent e)
        {
            var loan = await _loanRepository.Get(e.AggregateId);
            if (loan == null) throw new InvalidOperationException($"Loan {e.AggregateId} does not exist");

            loan.Balance += e.Amount;
            loan.LastChanged = e.TransactionDate;

            var loanTransaction = _mapper.Map<LoanTransactionEntity>(e);
            _loanTransactionRepository.Add(loanTransaction);

            await _loanRepository.SaveChangesAsync();
        }
    }
}