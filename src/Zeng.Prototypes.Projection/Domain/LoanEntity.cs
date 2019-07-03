using System;
using System.Collections.Generic;

namespace Zeng.Prototypes.Projection.Domain
{
    public class LoanEntity
    {
        public Guid Id { get; set; }
        public string LoanFriendlyId { get; set; }
        public decimal? LoanAmount { get; set; }
        public string RequirementAndObjective { get; set; }
        public string LoanCreationDate { get; set; }
        public string LoanType { get; set; }
        public bool IsLoanKRated { get; set; }
        public bool IsLoanFailed { get; set; }
        public bool IsLoanWrittenOff { get; set; }
        public bool IsLoanInHardship { get; set; }
        public bool IsLoanCanceled { get; set; }
        public bool IsLoanSettled { get; set; }
        public bool IsLoanOverpaid { get; set; }
        public bool IsLoanDisbursed { get; set; }
        public DateTimeOffset? LoanSettlementDate { get; set; }
        public bool IsLoanPaymentMethodAuto { get; set; }
        public string Frequency { get; set; }
        public decimal? CreditLimit { get; set; }
        public DateTimeOffset? LocClosedDate { get; set; }
        public decimal Balance { get; set; }
        public DateTimeOffset LastChanged { get; set; }

        public ICollection<LoanTransactionEntity> Transactions { get; set; }
    }
}