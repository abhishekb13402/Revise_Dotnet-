using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Model
{
    public class UserAuth
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Email{ get; set;}
        [Required]
        public string Password { get; set;}
    }
}
