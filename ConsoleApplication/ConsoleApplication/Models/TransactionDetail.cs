using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Models
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public string CreditCardNumber { get; set; }
        public double Amount { get; set; }
        public string CardType { get; set; }
        public DateTime Date { get; set; }
    }
}
