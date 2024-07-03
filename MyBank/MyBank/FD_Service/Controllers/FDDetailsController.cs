using FD_Service.Data;
using FD_Service.Model.Dto;
using FD_Service.Repository;
using FD_Service.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FDDetailsController : ControllerBase
    {
        private readonly FDDBContext fDDBContext;
        private readonly IFDDetailsRepository _fDDetailsRepository;

        public FDDetailsController(FDDBContext fDDBContext,IFDDetailsRepository fDDetailsRepository)
        {
            this.fDDBContext = fDDBContext;
            this._fDDetailsRepository = fDDetailsRepository;
        }

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<FDDetailsDto>> AddFDDetails(FDDetailsDto fDDetailsDto)
        {
            try
            {
                var result = await _fDDetailsRepository.AddFDDetails(fDDetailsDto);
                return Ok(result);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<FDDetailsDto>> GetFDDetails()
        {
            try
            {
                var result = await _fDDetailsRepository.GetAllFDDetails();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
