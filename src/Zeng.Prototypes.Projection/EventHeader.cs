﻿namespace Zeng.Prototypes.Projection
{
    public class EventHeader
    {
        public long SequenceId { get; set; }
        public int AggregateTypeId { get; set; }
        public int MessageTypeId { get; set; }
        public string BlobUri { get; set; }
    }
}