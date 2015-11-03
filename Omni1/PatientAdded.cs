using System;

namespace MessageBusPOC.Contracts
{
    public interface PatientAdded
    {
        Guid EventId { get; }
        DateTime Timestamp { get; }
        string PatientName { get; }
    }

}
