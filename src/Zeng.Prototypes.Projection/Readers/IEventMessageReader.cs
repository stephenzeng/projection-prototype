using System.Collections.Generic;
using System.Threading.Tasks;
using Zeng.Prototypes.Projection.Common;

namespace Zeng.Prototypes.Projection.Readers
{
    public interface IEventMessageReader
    {
        Task<IEnumerable<EventMessage>> ReadAsync(IEnumerable<EventHeader> eventHeaders);
    }
}