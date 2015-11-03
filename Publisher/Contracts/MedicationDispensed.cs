using System;

namespace MessageBusPOC.Contracts
{
    public interface MedicationDispensed
    {
        Guid EventId { get; }
        DateTime Timestamp { get; }
        string Name { get; }
    }
}