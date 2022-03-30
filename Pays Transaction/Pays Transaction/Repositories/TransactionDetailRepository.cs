using Pays_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pays_Transaction.Repositories
{
    public class TransactionDetailRepository : ITransactionDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddDetail(TransactionDetail detail)
        {
            _context.TransactionDetails.Add(detail);
            _context.SaveChanges();
        }

        public void DeleteDetail(int id)
        {
            var data = _context.TransactionDetails.FirstOrDefault(x => x.Id == id);
            if (data == null)
                throw new SystemException();
            _context.TransactionDetails.Remove(data);
            _context.SaveChanges();
        }

        public TransactionDetail GetTransactionDetailById(int id)
        {
            var data = _context.TransactionDetails.FirstOrDefault(x => x.Id == id);
            if (data == null)
                throw new SystemException();
            return data;
        }

        public List<TransactionDetail> GetTransactionDetails()
        {
            return _context.TransactionDetails.ToList();
        }

        public void UpdateDetail(TransactionDetail detail)
        {
            _context.Entry(detail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
