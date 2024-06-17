using System.ComponentModel.DataAnnotations;

namespace Practice.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string EmployeeEmail { get; set; }

        public EmployeeDetails employeeDetails { get; set; }
        public SalaryDetails salaryDetails { get; set; }
        public EmployeeAuth employeeAuth{ get; set; }

    }
}
