using System;
using Zeng.Prototypes.Projection.Common;

namespace Zeng.Prototypes.Projection.Domain
{
    public class LoanTransactionEntity
    {
        public Guid Id { get; set; }
        public Guid LoanId { get; set; }
        public LoanEntity Loan { get; set; }

        public DateTimeOffset TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public LedgerTransactionType TransactionType{ get; set; }
    }
}