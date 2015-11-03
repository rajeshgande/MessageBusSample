using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;
using MessageBusPOC.Contracts;

namespace ReportingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Omnicell Reporting System--------");
            Log4NetLogger.Use();
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cfg.ReceiveEndpoint(host, "Reporting_queue", e =>
                {
                    e.Handler<PatientAdded>(
                        context => Console.Out.WriteLineAsync($"Patient Added: {context.Message.PatientName}"));
                });
            });
            var busHandle = bus.Start();
            Console.WriteLine("Enter any key to quit. ");
            Console.ReadKey();
            busHandle.Stop();
        }
    }
}
