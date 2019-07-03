using System.Collections.Generic;
using System.Threading.Tasks;
using Zeng.Prototypes.Projection.Common;
using Zeng.Prototypes.Projection.Domain;

namespace Zeng.Prototypes.Projection.Readers
{
    public interface IEventHeaderReader
    {
        Task<IEnumerable<EventHeader>> ReadAsync(IEnumerable<EventBookmarkEntity> eventBookmarks);
    }
}