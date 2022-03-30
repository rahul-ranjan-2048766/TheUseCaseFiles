using Bill_Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bill_Generator.Repositories;

namespace Bill_Generator.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository repository;
        public BillService(IBillRepository billRepository)
        {
            repository = billRepository;
        }

        public void AddBill(Bill bill)
        {
            repository.AddBill(bill);
        }

        public void DeleteBill(int id)
        {
            repository.DeleteBill(id);
        }

        public void DeleteBills()
        {
            repository.DeleteBills();
        }

        public Bill GetBillById(int id)
        {
            return repository.GetBillById(id);
        }

        public List<Bill> GetBills()
        {
            return repository.GetBills();
        }

        public void UpdateBill(Bill bill)
        {
            throw new NotImplementedException();
        }
    }
}
