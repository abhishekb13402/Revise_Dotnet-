    using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Model;
using Practice.Model.Dto;

namespace Practice.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this._mapper = mapper;
        }

        public async Task<EmployeeDto> AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var employeedata = _mapper.Map<Employee>(employeeDto);
                employeedata.EmployeeEmail = employeeDto.EmployeeEmail;
                await appDbContext.employees.AddAsync(employeedata);
                await appDbContext.SaveChangesAsync();

                var detailsdata = _mapper.Map<EmployeeDetails>(employeeDto.Details);
                detailsdata.EmployeeId = employeedata.Id;
                //detailsdata.DOB = employeedata.employeeDetails.DOB;
                //detailsdata.Email = employeedata.employeeDetails.Email;
                //detailsdata.Phone = employeedata.employeeDetails.Phone;
                await appDbContext.EmployeeDetails.AddAsync(detailsdata);
                await appDbContext.SaveChangesAsync();
                
                var empdata = _mapper.Map<EmployeeDto>(employeedata);
                return employeeDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var emprecord = appDbContext.employees.Find(id);
                if (emprecord != null)
                {
                    appDbContext.employees.Remove(emprecord);
                    await appDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteEmployeeByFilter(string value)
        {
            //value is name or email 
            try
            {
                var employees = await appDbContext.employees
                    .Where(e => e.Name == value || e.employeeDetails.Email == value)
                    .FirstOrDefaultAsync();
                if (employees == null)
                {
                    return false;
                }
                appDbContext.employees.Remove(employees);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeDto> GetByFilter(string value)
        {
            try
            {
                var employee = await appDbContext.employees
                    .Where(e => e.Name == value || e.employeeDetails.Email == value)
                    .Include(e => e.employeeDetails)
                    .FirstOrDefaultAsync();

                if (employee == null)
                {
                    return null;
                }

                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return employeeDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeDto> GetById(int id)
        {
            try
            {
                var employee = await appDbContext.employees
                    .Include(e => e.employeeDetails)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (employee == null)
                {
                    return null;
                }

                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return employeeDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<EmployeeDto>> GetAll()
        {
            try
            {
                var employee = await appDbContext.employees
                    .Include(e => e.employeeDetails).ToListAsync();

                if (employee == null)
                {
                    return null;
                }

                var employeeDto = _mapper.Map<List<EmployeeDto>>(employee);
                return employeeDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var employee = await appDbContext.employees
                    .Include(e => e.employeeDetails)
                    .FirstOrDefaultAsync(e => e.Id == employeeDto.Id);

                if (employee == null)
                {
                    throw new Exception("User not found");
                }

                employee.Name = employeeDto.Name;
                employee.EmployeeEmail = employeeDto.EmployeeEmail;

                if (employee.employeeDetails != null)
                {
                    employee.employeeDetails.DOB = employeeDto.Details.DOB;
                    employee.employeeDetails.Email = employeeDto.Details.Email;
                    employee.employeeDetails.Phone = employeeDto.Details.Phone;
                }
                else
                {
                    employee.employeeDetails = new EmployeeDetails
                    {
                        EmployeeId = employeeDto.Id,
                        DOB = employeeDto.Details.DOB,
                        Email = employeeDto.Details.Email,
                        Phone = employeeDto.Details.Phone
                    };
                }

                appDbContext.Update(employee);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the employee.", ex);
            }
        }

    }
}
