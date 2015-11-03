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
            await Console.Out.WriteLineAsync($"Patinet Added: {context.Message.PatientName}");
        }
    }
}