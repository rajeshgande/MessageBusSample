using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;
using MessageBusPOC.Contracts;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Omnicell Administration System--------");
            Log4NetLogger.Use();
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "customer_update_queue", e =>
                {
                    e.Consumer<PatientAddedConsumer>();
                });
            });

            var busHandle = bus.Start();
            var patientName = "";

            Console.WriteLine("Enter 'q' to quit. ");
            while (patientName != "q")
            {
                Console.Write("Enter Patient: ");
                patientName = Console.ReadLine();

                var message = new PatientAddedImpl(patientName: patientName);
                bus.Publish<PatientAdded>(message);
            }

            busHandle.Stop();
        }
    }
}
