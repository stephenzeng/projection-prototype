using Zeng.Prototypes.Projection.Common;

namespace Zeng.Prototypes.Projection.Events
{
    public class LoanConfiguration
    {
        public LoanType? LoanType { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal ContractValue { get; set; }
        public decimal EstablishmentFee { get; set; }
        public decimal DefaultFee { get; set; }
        public decimal? RequiredLoanAmount { get; set; }
        public string RequirementAndObjective { get; set; }
        public decimal? CreditLimit { get; set; }
    }
}