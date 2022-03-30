using System;
using System.Collections.Generic;
using ConsoleApplication.Models;
using ConsoleApplication.Services;
using ConsoleApplication.Repositories;
using System.IO;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    class Program
    {
        private static ITransactionDetailRepository repository;
        private static ITransactionDetailService service;

        static void SaveDataToCSV(List<TransactionDetail> details)
        {
            var text = "";
            foreach(var detail in details)
            {
                text += detail.Id + "," + detail.TransactionId + "," + detail.CreditCardNumber + "," + detail.CardType + "," + detail.Amount + "," + detail.Date + "\n";
            }
            using (var writer = new StreamWriter(@"C:\Users\2048766\AngularWebsites\UseCase\ConsoleApplication\ConsoleApplication\details.csv"))
            {
                writer.Write(text);
            }
        }

        static void SaveToRabbitMQ(List<TransactionDetail> details)
        {
            var text = "";
            foreach (var detail in details)
            {
                text += detail.Id.ToString() + "," + detail.TransactionId.ToString() + "," + detail.CreditCardNumber.ToString() + "," + detail.CardType.ToString() + "," + detail.Amount.ToString() + "," + detail.Date.ToString() + ";";
            }

            text = text.Substring(0, text.Length - 1);

            
            var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
            factory.AutomaticRecoveryEnabled = true;
            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel()) 
            {
                channel.QueueDeclare("demo-queue", true, false, false);
                channel.BasicPublish("", "demo-queue", null, Encoding.UTF8.GetBytes(text));
            }
        }

        static void Main(string[] args)
        {
            repository = new TransactionDetailRepository();
            service = new TransactionDetailService(repository);
            var details = service.GetTransactionDetails();
            //SaveDataToCSV(details);
            SaveToRabbitMQ(details);
            Console.WriteLine("The data is successfully saved to CSV File....");
        }
    }
}
