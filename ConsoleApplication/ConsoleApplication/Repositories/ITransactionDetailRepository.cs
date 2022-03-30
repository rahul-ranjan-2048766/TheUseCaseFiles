using ConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Repositories
{
    public interface ITransactionDetailRepository
    {
        public List<TransactionDetail> GetTransactionDetails();
    }
}
