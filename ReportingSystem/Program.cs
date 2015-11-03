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
        public static int PatientCount = 0;
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
                        context =>
                        {
                            PatientCount++;
                            return Console.Out.WriteLineAsync(
                                $"Patient '{context.Message.PatientName}' added at {context.Message.Timestamp}");
                        });
                    e.Handler<RequestPatientCount>(
                       context =>
                       {
                           Console.WriteLine("Patient Count Requested...");
                           context.Respond<PatientCountResponse>(new PatientCountResponseImpl(PatientCount));
                           return Console.Out.WriteLineAsync(
                               $"Returned Patient Count:{PatientCount}");
                       });
                    e.Handler<MedicationDispensed>(
                       context => Console.Out.WriteLineAsync($"Medication '{context.Message.Name}' dispensed at {context.Message.Timestamp}"));
                });
            });
            var busHandle = bus.Start();
            Console.WriteLine("Enter any key to quit. ");
            Console.ReadKey();
            busHandle.Stop();
        }
    }
}
