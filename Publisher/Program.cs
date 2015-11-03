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
            Console.Title = "Omnicell Administration System";
            Console.WriteLine("-----Omnicell Administration System--------");
            Log4NetLogger.Use();
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
              
            });

            var busHandle = bus.Start();
            bool quit = false;

            Console.WriteLine("Enter 'q' to quit. ");
            while (!quit)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Enter 1. Add Patient 2.Dispense Medication 3.Request Patient Count 4.Quit");
                var option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Write("Enter Patient Name: ");
                        var patientName = Console.ReadLine();
                        bus.Publish<PatientAdded>(new PatientAddedImpl(patientName: patientName));
                        Console.WriteLine("Patient added.");
                        break;
                    case 2:
                        Console.Write("Dispense Medication: ");
                        string medName = Console.ReadLine();
                        bus.Publish<MedicationDispensed>(new MedicationDispensedImpl(name: medName));
                        break;
                    case 3:
                        Console.Write("Requesting Patient Count....");
                         bus.PublishRequest<RequestPatientCount>(new RequestPatientCountImpl(), x =>
                        {
                            x.Handle<PatientCountResponse>(message => Console.Out.WriteLineAsync("patient Count:" + message.Message.Count.ToString()));
                            x.Timeout = new TimeSpan(0, 0, 0, 30);
                        });
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        Console.Write("Invalid option. Try again");
                        break;
                }
              

              
            }

            busHandle.Stop();
        }
    }
}
