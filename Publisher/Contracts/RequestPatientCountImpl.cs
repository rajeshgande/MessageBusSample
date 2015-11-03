using System;
using MassTransit;

namespace MessageBusPOC.Contracts
{
    class RequestPatientCountImpl : RequestPatientCount
    {
        public Guid CommandId { get; }
        public DateTime Timestamp { get; }

        public RequestPatientCountImpl()
        {
            CommandId = NewId.NextGuid();
            Timestamp = DateTime.UtcNow;
        }

    }
}