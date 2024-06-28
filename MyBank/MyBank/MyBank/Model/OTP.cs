using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBank.Model
{
    public class OTP
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AccountId")]
        [Required]
        public int AccountId{ get; set; }
        public Account Account { get; set; }
        
        [Required]
        public string OTPValue{ get; set; }
        
        [Required]
        public DateTime ExpiryTime{ get; set; }
        
        [Required]
        public bool IsUsed { get; set; }

    }
}
