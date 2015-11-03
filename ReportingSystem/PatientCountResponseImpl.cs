using System;
using MassTransit;

namespace MessageBusPOC.Contracts
{
    class PatientCountResponseImpl : PatientCountResponse
    {
        public Guid EventId { get; }
        public DateTime Timestamp { get; }
        public int Count { get; }


        public PatientCountResponseImpl(int cnt)
        {
            EventId = NewId.NextGuid();
            Timestamp = DateTime.UtcNow;
            Count = cnt;
        }
    }
}