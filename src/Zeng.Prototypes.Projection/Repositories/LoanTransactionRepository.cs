using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zeng.Prototypes.Projection.Domain;

namespace Zeng.Prototypes.Projection.Repositories
{
    public class LoanTransactionRepository : IRepository<LoanTransactionEntity>
    {
        private readonly ApplicationDbContext _dbContext;

        public LoanTransactionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(LoanTransactionEntity loanTransactionEntity)
        {
            _dbContext.LoanTransactions.Add(loanTransactionEntity);
        }

        public Task<LoanTransactionEntity> Get(Guid id)
        {
            return _dbContext.LoanTransactions.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}