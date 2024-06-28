using System.ComponentModel.DataAnnotations;

namespace MyBank.Model
{
    public class OTP
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string OTPValue{ get; set; }
        
        [Required]
        public DateTime ExpiryTime{ get; set; }
        
        [Required]
        public bool IsUsed { get; set; }

    }
}
