using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zeng.Prototypes.Projection.Domain;

namespace Zeng.Prototypes.Projection.Repositories
{
    public class CustomerRepository: IRepository<CustomerEntity>
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(CustomerEntity customerEntity)
        {
            _dbContext.Customers.Add(customerEntity);
        }

        public Task<CustomerEntity> Get(Guid id)
        {
            return _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}