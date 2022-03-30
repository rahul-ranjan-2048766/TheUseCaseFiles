using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bill_Generator.Models;

namespace Bill_Generator.Helpers
{
    interface ITransactionReader
    {
        public string GetTransactionDetailsFromRabbitMQ();
        public List<TransactionDetail> GetTransactionDetails();
        public void PrintDetails(List<TransactionDetail> details);
    }
}
