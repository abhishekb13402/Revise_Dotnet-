namespace Practice.Model.Dto
{
    public class EmployeeDto
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
       
        public EmployeeDetailsDto Details { get; set; }
    }
}
