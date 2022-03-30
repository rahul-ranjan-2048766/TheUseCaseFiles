using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pays_Transaction.Models;

namespace Pays_Transaction.Services
{
    public interface ITransactionDetailService
    {
        public void AddDetail(TransactionDetail detail);
        public void DeleteDetail(int id);
        public TransactionDetail GetTransactionDetailById(int id);
        public List<TransactionDetail> GetTransactionDetails();
        public void UpdateDetail(TransactionDetail detail);
    }
}
