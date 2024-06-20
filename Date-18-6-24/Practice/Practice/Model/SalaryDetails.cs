using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Model
{
    public class SalaryDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        
        public Employee Employee { get; set; }

        [Required]
        public string Amount { get; set; }

    }
}
