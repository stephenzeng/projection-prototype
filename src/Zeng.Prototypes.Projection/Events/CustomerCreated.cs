using System;
using Zeng.Prototypes.Projection.Common;

namespace Zeng.Prototypes.Projection.Events
{
    public class CustomerCreated : EventMessage
    {
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string FriendlyId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
    }
}