using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.Models;

namespace ConsoleApplication.Repositories
{
    public class TransactionDetailRepository : ITransactionDetailRepository
    {
        public List<TransactionDetail> GetTransactionDetails()
        {
            List<TransactionDetail> transactionDetails = new List<TransactionDetail>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/TransactionDetail/");
                var responseTask = client.GetAsync("GetTransactionDetails");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var reader = result.Content.ReadAsAsync<List<TransactionDetail>>();
                    reader.Wait();
                    transactionDetails = reader.Result;
                }
                else
                {
                    transactionDetails = null;
                }
            }
            return transactionDetails;
        }
    }
}
