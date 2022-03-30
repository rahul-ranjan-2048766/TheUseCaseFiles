using Pays_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pays_Transaction.Repositories
{
    public interface ITransactionDetailRepository
    {
        public void AddDetail(TransactionDetail detail);
        public void DeleteDetail(int id);
        public TransactionDetail GetTransactionDetailById(int id);
        public List<TransactionDetail> GetTransactionDetails();
        public void UpdateDetail(TransactionDetail detail);
    }
}
