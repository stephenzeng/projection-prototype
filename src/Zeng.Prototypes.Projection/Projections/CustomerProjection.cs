using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeng.Prototypes.Projection.Domain;
using Zeng.Prototypes.Projection.Events;

namespace Zeng.Prototypes.Projection.Projections
{
    public class CustomerProjection: Projection, IProjection
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerProjection(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task When(CustomerCreated e)
        {
            var customer = _mapper.Map<CustomerEntity>(e);
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task When(CustomerChanged e)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == e.AggregateId);
            if (customer == null) throw new InvalidOperationException($"Customer {e.AggregateId} does not exist");

            _mapper.Map(e, customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}