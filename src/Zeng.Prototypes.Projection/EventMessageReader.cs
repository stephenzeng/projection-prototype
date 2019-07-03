﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zeng.Prototypes.Projection.Common;

namespace Zeng.Prototypes.Projection
{
    public interface IEventMessageReader
    {
        Task<IEnumerable<EventMessage>> ReadAsync(IEnumerable<EventHeader> eventHeaders);
    }

    public class EventMessageReader : IEventMessageReader
    {
        public Task<IEnumerable<EventMessage>> ReadAsync(IEnumerable<EventHeader> eventHeaders)
        {
            return Task.FromResult(Enumerable.Empty<EventMessage>());
        }
    }
}