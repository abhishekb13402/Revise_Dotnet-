using FD_Service.Data;
using FD_Service.Model.Dto;
using FD_Service.Repository;
using FD_Service.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFDDetailsController : ControllerBase
    {
        private readonly FDDBContext fDDBContext;
        private readonly ICustomerFDDetailsRepository _customerFDDetailsRepository;

        public CustomerFDDetailsController(FDDBContext fDDBContext, ICustomerFDDetailsRepository customerFDDetailsRepository)
        {
            this.fDDBContext = fDDBContext;
            _customerFDDetailsRepository = customerFDDetailsRepository;
        }
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<CustomerFDDetailsDto>> AddCustomerFDDetails(CustomerFDDetailsDto customerFDDetailsDto)
        {
            try
            {
                var result = await _customerFDDetailsRepository.AddCustomerFDDetails(customerFDDetailsDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<CustomerFDDetailsDto>> GetAllCustomerFDDetails()
        {
            try
            {
                var result = await _customerFDDetailsRepository.GetAllCustomerFDDetails();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
