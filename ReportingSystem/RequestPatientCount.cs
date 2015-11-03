using System;

namespace MessageBusPOC.Contracts
{
    public interface RequestPatientCount
    {
        Guid CommandId { get; }
        DateTime Timestamp { get; }
    }
}