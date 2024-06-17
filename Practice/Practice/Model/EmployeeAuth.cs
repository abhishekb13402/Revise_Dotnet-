using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Model
{
    public class EmployeeAuth
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [ForeignKey("EmployeeEmail")]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(8)]
        public string Password { get; set; }

        public Employee employee { get; set; }


    }
}
