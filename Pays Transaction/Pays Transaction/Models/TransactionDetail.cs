using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pays_Transaction.Models
{
    public class TransactionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TransactionId { get; set; }

        [DataType(DataType.CreditCard)]
        public string CreditCardNumber { get; set; }
        public double Amount { get; set; }
        public string CardType { get; set; }
        public DateTime Date { get; set; }
    }
}
