using System;

namespace Zeng.Prototypes.Projection.Domain
{
    public class EventBookmarkEntity
    {
        public int Id { get; set; }
        public int AggregateTypeId { get; set; }
        public int MessageTypeId { get; set; }
        public Type EventType { get; set; }
        public long Position { get; set; }
    }
}
