using Bill_Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Bill_Generator.Helpers
{
    public class TransactionReader : ITransactionReader
    {
        private string text = "agtfdcgfc";
        private List<TransactionDetail> transactionDetails;
        public string GetTransactionDetailsFromRabbitMQ()
        {
            var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
            factory.AutomaticRecoveryEnabled = true;
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            BasicGetResult result = channel.BasicGet("demo-queue", false);
            if(result != null)
            {
                text = Encoding.UTF8.GetString(result.Body.ToArray());
                Console.WriteLine(text);
                channel.BasicAck(result.DeliveryTag, false);
            }
            return text;
        }

        public List<TransactionDetail> GetTransactionDetails()
        {
            var line = "";
            List<TransactionDetail> transactionDetails = new List<TransactionDetail>();

            using (var reader = new StreamReader(@"C:\Users\2048766\AngularWebsites\UseCase\ConsoleApplication\ConsoleApplication\details.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var lineSplit = line.Split(',').ToList();
                    transactionDetails.Add(new TransactionDetail 
                    { 
                        Id = int.Parse(lineSplit.ElementAt(0)),
                        TransactionId = int.Parse(lineSplit.ElementAt(1)),
                        CreditCardNumber = lineSplit.ElementAt(2),
                        CardType = lineSplit.ElementAt(3),
                        Amount = double.Parse(lineSplit.ElementAt(4)),
                        Date = DateTime.Parse(lineSplit.ElementAt(5))
                    });
                }
            }
            return transactionDetails;
        }

        public void PrintDetails(List<TransactionDetail> details)
        {
            Console.WriteLine("Id TransactionId CreditCardNumber CardType Amount Date");
            foreach(var detail in details)
            {
                Console.WriteLine(detail.Id + " " + detail.TransactionId + " " + detail.CreditCardNumber + " " + detail.CardType + " " + detail.Amount + " " + detail.Date);
            }
        }
    }
}
