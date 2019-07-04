using System;
using System.Threading.Tasks;
using AutoMapper;
using Zeng.Prototypes.Projection.Domain;
using Zeng.Prototypes.Projection.Events;
using Zeng.Prototypes.Projection.Repositories;

namespace Zeng.Prototypes.Projection.Projections
{
    public class CustomerProjection: Projection, IProjection
    {
        private readonly IRepository<CustomerEntity> _repository;
        private readonly IMapper _mapper;

        public CustomerProjection(IRepository<CustomerEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task When(CustomerCreated e)
        {
            var customer = _mapper.Map<CustomerEntity>(e);
            _repository.Add(customer);
            await _repository.SaveChangesAsync();
        }

        public async Task When(CustomerChanged e)
        {
            var customer = await _repository.Get(e.AggregateId);
            if (customer == null) throw new InvalidOperationException($"Customer {e.AggregateId} does not exist");

            _mapper.Map(e, customer);
            await _repository.SaveChangesAsync();
        }
    }
}