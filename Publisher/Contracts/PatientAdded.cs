using System;
using MassTransit;

namespace MessageBusPOC.Contracts
{
    public interface PatientAdded
    {
        Guid EventId { get; }
        DateTime Timestamp { get; }
        string PatientName { get; }
    }

    public class PatientAddedImpl : PatientAdded
    {
        public PatientAddedImpl(string patientName)
        {
            EventId = NewId.NextGuid();
            Timestamp = DateTime.UtcNow;
            PatientName = patientName;
        }

        public Guid EventId { get; }
        public DateTime Timestamp { get; }
        public string PatientName { get; }
    }
}