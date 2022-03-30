using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bill_Generator.Models;

namespace Bill_Generator.Repositories
{
    public interface IBillRepository
    {
        public void AddBill(Bill bill);
        public void DeleteBill(int id);
        public Bill GetBillById(int id);
        public List<Bill> GetBills();
        public void UpdateBill(Bill bill);
        public void DeleteBills();
    }
}
