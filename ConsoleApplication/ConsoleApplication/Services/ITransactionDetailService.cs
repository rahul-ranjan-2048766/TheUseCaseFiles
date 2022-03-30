using ConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Services
{
    public interface ITransactionDetailService
    {
        public List<TransactionDetail> GetTransactionDetails();
    }
}
