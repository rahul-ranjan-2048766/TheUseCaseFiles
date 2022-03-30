using ConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.Repositories;

namespace ConsoleApplication.Services
{
    public class TransactionDetailService : ITransactionDetailService
    {
        private readonly ITransactionDetailRepository repository;
        public TransactionDetailService(ITransactionDetailRepository transactionDetailRepository)
        {
            repository = transactionDetailRepository;
        }

        public List<TransactionDetail> GetTransactionDetails()
        {
            return repository.GetTransactionDetails();
        }
    }
}
