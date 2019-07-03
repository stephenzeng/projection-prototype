using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zeng.Prototypes.Projection.Common;
using Zeng.Prototypes.Projection.Domain;

namespace Zeng.Prototypes.Projection.Readers
{
    public class EventHeaderReader : IEventHeaderReader
    {
        public Task<IEnumerable<EventHeader>> ReadAsync(IEnumerable<EventBookmarkEntity> eventBookmarks)
        {
            //update bookmark's position here
            return Task.FromResult(Enumerable.Empty<EventHeader>());
        }
    }
}