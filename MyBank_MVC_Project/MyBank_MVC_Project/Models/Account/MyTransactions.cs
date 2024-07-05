using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBank_MVC_Project.Models.Account
{
    public class MyTransactions
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PersonId")]
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey("FromAccountId")]
        public int FromAccountId { get; set; }
        public Account FromAccount { get; set; }

        [ForeignKey("ToAccountId")]
        public int ToAccountId { get; set; }
        public Account ToAccount { get; set; }


        [Required]
        public double Amount { get; set; }

        [Required]
        public TransactionType transactionType { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
    public enum TransactionType
    {
        Deposit,
        Withdraw,
        FundsTransfer
    }
}
