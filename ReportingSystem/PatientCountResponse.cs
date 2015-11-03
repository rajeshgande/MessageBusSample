using System;

namespace MessageBusPOC.Contracts
{
    public interface PatientCountResponse
    {
        Guid EventId { get; }
        DateTime Timestamp { get; }
        int Count { get;  }
    }
}