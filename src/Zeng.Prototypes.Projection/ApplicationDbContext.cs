using Microsoft.EntityFrameworkCore;
using Zeng.Prototypes.Projection.Domain;

namespace Zeng.Prototypes.Projection
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<EventBookmarkEntity> EventBookmarks { get; set; }
        public DbSet<LoanTransactionEntity> LoanTransactions { get; set; }
    }
}
