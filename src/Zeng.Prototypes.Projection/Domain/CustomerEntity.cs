using System;

namespace Zeng.Prototypes.Projection.Domain
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
    }
}