using System;
using Zeng.Prototypes.Projection.Common;

namespace Zeng.Prototypes.Projection.Events
{
    public class LoanLedgerEvent : EventMessage
    {
        public decimal Amount { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public DateTimeOffset EffectiveDate { get; set; }
        public LedgerTransactionType TransactionType { get; set; }
    }
}