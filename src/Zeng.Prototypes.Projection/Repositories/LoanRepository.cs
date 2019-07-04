using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zeng.Prototypes.Projection.Domain;

namespace Zeng.Prototypes.Projection.Repositories
{
    public class LoanRepository : IRepository<LoanEntity>
    {
        private readonly ApplicationDbContext _dbContext;

        public LoanRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(LoanEntity loanEntity)
        {
            _dbContext.Loans.Add(loanEntity);
        }

        public Task<LoanEntity> Get(Guid id)
        {
            return _dbContext.Loans.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}