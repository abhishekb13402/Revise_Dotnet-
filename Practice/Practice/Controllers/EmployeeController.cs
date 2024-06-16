using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.Model.Dto;
using Practice.Repository;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(AppDbContext appDbContext, IEmployeeRepository employeeRepository)
        {
            this.appDbContext = appDbContext;
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<EmployeeDto>> AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var result = await _employeeRepository.AddEmployee(employeeDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("DeleteById")]
        //[Authorize]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            try
            {
                var result = await _employeeRepository.DeleteEmployee(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("Update")]
        //[Authorize]
        public async Task<ActionResult<bool>> UpdateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var result = await _employeeRepository.UpdateEmployee(employeeDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("DeleteByFilter-name,email")]
        //[Authorize]
        public async Task<ActionResult<bool>> DeleteEmployeeByFilter(string value)
        {
            try
            {
                var result = await _employeeRepository.DeleteEmployeeByFilter(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetAll")]
        //[Authorize]
        public async Task<ActionResult<EmployeeDto>> GetAll()
        {
            try
            {
                var result = await _employeeRepository.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetById")]
        //[Authorize]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            try
            {
                var result = await _employeeRepository.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetByFilter-name,email")]
        //[Authorize]
        public async Task<ActionResult<EmployeeDto>> GetByFilter(string value)
        {
            try
            {
                var result = await _employeeRepository.GetByFilter(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
