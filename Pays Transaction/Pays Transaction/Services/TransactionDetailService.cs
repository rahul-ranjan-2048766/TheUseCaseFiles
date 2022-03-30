using Pays_Transaction.Models;
using Pays_Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pays_Transaction.Services
{
    public class TransactionDetailService : ITransactionDetailService
    {
        public readonly ITransactionDetailRepository repository;
        public TransactionDetailService(ITransactionDetailRepository transactionDetailRepository)
        {
            repository = transactionDetailRepository;
        }

        public void AddDetail(TransactionDetail detail)
        {
            repository.AddDetail(detail);
        }

        public void DeleteDetail(int id)
        {
            repository.DeleteDetail(id);
        }

        public TransactionDetail GetTransactionDetailById(int id)
        {
            return repository.GetTransactionDetailById(id);
        }

        public List<TransactionDetail> GetTransactionDetails()
        {
            return repository.GetTransactionDetails();
        }

        public void UpdateDetail(TransactionDetail detail)
        {
            repository.UpdateDetail(detail);
        }
    }
}
