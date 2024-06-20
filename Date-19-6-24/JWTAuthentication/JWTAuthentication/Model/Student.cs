using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
