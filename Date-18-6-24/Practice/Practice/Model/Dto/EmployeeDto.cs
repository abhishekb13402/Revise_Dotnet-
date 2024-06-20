namespace Practice.Model.Dto
{
    public class EmployeeDto
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string EmployeeEmail { get; set; }
        public EmployeeDetailsDto Details { get; set; }
    }
}
