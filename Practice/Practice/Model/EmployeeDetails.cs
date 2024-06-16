using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Model
{
    public class EmployeeDetails
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        public Employee employee { get; set; }

        [Required(ErrorMessage = "Email is require")]
        [StringLength(50)]
        public string Email { get; set; }
        
        [Required]
        public DateTime DOB { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
    }
}
