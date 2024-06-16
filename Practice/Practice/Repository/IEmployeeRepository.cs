using Practice.Model.Dto;

namespace Practice.Repository
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDto> GetById(int id);
        Task<List<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetByFilter(string value); //name,email
        Task<EmployeeDto> AddEmployee(EmployeeDto employeeDto);
        Task<bool> UpdateEmployee(EmployeeDto employeeDto);
        Task<bool> DeleteEmployee(int id);
        Task<bool> DeleteEmployeeByFilter(string value); //name, email
    }
}
