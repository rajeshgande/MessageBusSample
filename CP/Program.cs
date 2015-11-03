using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;
using MessageBusPOC.Contracts;

namespace CP
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger.Use();
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cfg.ReceiveEndpoint(host, "cp_queue", e =>
                {
                    e.Consumer<PatientAddedConsumer>();
                });
            });

            var busHandle = bus.Start();

            Console.WriteLine("Enter any key to quit. ");
            Console.ReadKey();
            busHandle.Stop();
        }
    }
}
