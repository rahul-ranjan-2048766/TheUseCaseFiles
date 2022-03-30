using Bill_Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Bill_Generator.Repositories
{
    public class BillRepository : IBillRepository
    {
        //private static string ConnectionString = @"Data Source=LTIN235237\MSSQLSERVER2019;Initial Catalog=DatabaseOfPaysTransaction;Integrated Security=True";,
        private static string ConnectionString = @"Data Source=127.0.0.1\{sql2019},1433;Initial Catalog=DatabaseTransaction;User ID=SA;Password=India46@$";
        public void AddBill(Bill bill)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);            
            SqlCommand command = new SqlCommand(@"insert into TableBill(TransactionId, CreditCardNumber, CardType, Amount, DateOfTransaction) values('" + bill.TransactionId + "', '" + bill.CreditCardNumber + "', '" + bill.CardType + "', '" + bill.Amount + "', '" + DateTime.Parse(bill.Date.ToString()) + "')", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();            
        }

        public void DeleteBill(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(@"delete from TableBill where Id='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Bill GetBillById(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(@"select * from TableBill where Id='" + id + "'", connection);
            connection.Open();
            SqlDataReader result = command.ExecuteReader();
            result.Read();
            var data = new Bill
            {
                TransactionId = int.Parse(result["TransactionId"].ToString()),
                CreditCardNumber = result["CreditCardNumber"].ToString(),
                CardType = result["CardType"].ToString(),
                Amount = double.Parse(result["Amount"].ToString()),
                Date = DateTime.Parse(result["DateOfTransaction"].ToString())
            };
            connection.Close();
            return data;
        }

        public List<Bill> GetBills()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(@"select * from TableBill", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            List<Bill> bills = new List<Bill>();
            while (dataReader.Read())
            {
                bills.Add(new Bill 
                { 
                    TransactionId = int.Parse(dataReader["TransactionId"].ToString()),
                    CreditCardNumber = dataReader["CreditCardNumber"].ToString(),
                    CardType = dataReader["CardType"].ToString(),
                    Amount = double.Parse(dataReader["Amount"].ToString()),
                    Date = DateTime.Parse(dataReader["DateOfTransaction"].ToString())
                });
            }
            connection.Close();
            return bills;
        }

        public void UpdateBill(Bill bill)
        {
            throw new NotImplementedException();
        }

        public void DeleteBills()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(@"delete from TableBill", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
