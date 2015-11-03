using System;
using System.Threading.Tasks;
using MassTransit;
using MessageBusPOC.Contracts;

namespace Publisher
{
    public class PatientAddedConsumer :
        IConsumer<PatientAdded>
    {
        public async Task Consume(ConsumeContext<PatientAdded> context)
        {
            await Console.Out.WriteLineAsync(
                                $"Patient '{context.Message.PatientName}' added at {context.Message.Timestamp}");
        }
    }
}