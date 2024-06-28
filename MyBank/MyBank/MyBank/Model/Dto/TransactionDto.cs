using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBank.Model.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public double Amount { get; set; }
        public TransactionType transactionType { get; set; }
        //public DateTime TimeStamp { get; set; }
    }
}
