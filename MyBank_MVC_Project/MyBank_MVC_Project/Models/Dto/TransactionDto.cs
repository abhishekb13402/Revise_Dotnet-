using MyBank_MVC_Project.Models.Account;

namespace MyBank_MVC_Project.Models.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int FromAccountId { get; set; }//sender self
        public int ToAccountId { get; set; }//receiver another acc
        public double Amount { get; set; }
        public TransactionType transactionType { get; set; }
    }
}
