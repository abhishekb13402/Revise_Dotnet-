using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBank_MVC_Project.Models.Account
{
    public class OTP
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AccountId")]
        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        [Required]
        public string OTPValue { get; set; }

        [Required]
        public DateTime ExpiryTime { get; set; }

        [Required]
        public bool IsUsed { get; set; }
    }
}
