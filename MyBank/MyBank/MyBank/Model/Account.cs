using System.ComponentModel.DataAnnotations;

namespace MyBank.Model
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "PersonId is required")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public AccountType accounttype { get; set; }

        [Required]
        public double Balance { get; set; }

        public string? OTPValue { get; set; }

        [Required]
        public DateTime ExpiryTime { get; set; }

        [Required]
        public bool IsOTPVerify { get; set; } = false;

        public ICollection<MyTransactions> TransactionsFrom { get; set; }
        public ICollection<MyTransactions> TransactionsTo { get; set; }
    }

    public enum AccountType
    {
        Saving,
        Current
    }

}
