using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zeng.Prototypes.Projection.Projections;
using Zeng.Prototypes.Projection.Readers;

namespace Zeng.Prototypes.Projection
{
    public interface IOrchestrator
    {
        Task ExecuteAsync();
    }

    public class Orchestrator: IOrchestrator
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEventHeaderReader _eventHeaderReader;
        private readonly IEventMessageReader _eventMessageReader;
        private readonly IEnumerable<IProjection> _projections;

        public Orchestrator(ApplicationDbContext dbContext, 
            IEventHeaderReader eventHeaderReader, 
            IEventMessageReader eventMessageReader, 
            IEnumerable<IProjection> projections)
        {
            _dbContext = dbContext;
            _eventHeaderReader = eventHeaderReader;
            _eventMessageReader = eventMessageReader;
            _projections = projections;
        }

        public async Task ExecuteAsync()
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                var bookmarks = await _dbContext.EventBookmarks.ToListAsync();
                var headers = await _eventHeaderReader.ReadAsync(bookmarks);
                var messages = await _eventMessageReader.ReadAsync(headers);

                foreach (var message in messages)
                {
                    foreach (var projection in _projections)
                    {
                        await ((dynamic) projection).When((dynamic) message);
                    }
                }

                await _dbContext.SaveChangesAsync();
                transaction.Commit();
            }
        }
    }
}