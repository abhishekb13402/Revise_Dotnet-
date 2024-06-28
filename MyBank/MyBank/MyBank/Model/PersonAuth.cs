using System.ComponentModel.DataAnnotations;

namespace MyBank.Model
{
    public class PersonAuth
    {
        [Key]
        public int Id { get; set; }

        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
