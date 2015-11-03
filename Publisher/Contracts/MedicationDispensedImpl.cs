using System;
using MassTransit;

namespace MessageBusPOC.Contracts
{
    public class MedicationDispensedImpl : MedicationDispensed
    {
        public MedicationDispensedImpl(string name)
        {
            EventId = NewId.NextGuid();
            Timestamp = DateTime.UtcNow;
            Name = name;
        }

        public Guid EventId { get; }
        public DateTime Timestamp { get; }
        public string Name { get; }
    }
}