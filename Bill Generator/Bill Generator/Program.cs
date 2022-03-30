using System;
using Bill_Generator.Helpers;
using Bill_Generator.Models;
using Bill_Generator.Services;
using Bill_Generator.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace Bill_Generator
{
    class Program
    {
        private static ITransactionReader reader;
        private static IBillService service;
        private static IBillRepository repository;

        static Program()
        {
            reader = new TransactionReader();
            
            repository = new BillRepository();
            service = new BillService(repository);
        }
        static void PrintBills(List<Bill> bills)
        {
            foreach (var bill in bills)
            {
                Console.WriteLine(bill.TransactionId + " " + bill.CreditCardNumber + " " + bill.CardType + " " + bill.Amount + " " + bill.Date);
            }
        }

        static void AddTransactionDetailsToBills(List<TransactionDetail> details)
        {
            foreach(var detail in details)
            {
                service.AddBill(new Bill
                {
                    TransactionId = detail.TransactionId,
                    CreditCardNumber = detail.CreditCardNumber,
                    CardType = detail.CardType,
                    Amount = detail.Amount,
                    Date = detail.Date
                });
            }
        }

        static List<TransactionDetail> ConvertTextToList(string text)
        {
            List<TransactionDetail> transactionDetails = new List<TransactionDetail>();
            var lines = text.Split(';');
            foreach(var line in lines)
            {
                var data = line.Split(',').ToList();
                transactionDetails.Add(new TransactionDetail 
                { 
                    Id = int.Parse(data.ElementAt(0)),
                    TransactionId = int.Parse(data.ElementAt(1)),
                    CreditCardNumber = data.ElementAt(2),
                    CardType = data.ElementAt(3),
                    Amount = double.Parse(data.ElementAt(4)),
                    Date = DateTime.Parse(data.ElementAt(5))
                });
            }
            Console.WriteLine(text);
            return transactionDetails;
        }
        
        static void Main(string[] args)
        {
            ////var transactionDetails = reader.GetTransactionDetails();
            ////service.DeleteBills();
            ////AddTransactionDetailsToBills(transactionDetails);
            ////PrintBills(service.GetBills());
            var data = reader.GetTransactionDetailsFromRabbitMQ();
            var transactionDetails = ConvertTextToList(data);
            service.DeleteBills();
            AddTransactionDetailsToBills(transactionDetails);
            PrintBills(service.GetBills());
        }
    }
}
