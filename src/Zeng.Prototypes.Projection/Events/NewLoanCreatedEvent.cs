using System;
using Zeng.Prototypes.Projection.Common;

namespace Zeng.Prototypes.Projection.Events
{
    public class NewLoanCreatedEvent : EventMessage
    {
        public string FriendlyId { get; set; }
        public DateTimeOffset LoanCreationTimestamp { get; set; }
        public LoanConfiguration Configuration { get; set; }
        public bool IsLoanFailed { get; set; }
        public bool IsLoanWrittenOff { get; set; }
    }
}