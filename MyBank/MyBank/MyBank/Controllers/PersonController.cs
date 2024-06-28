using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBank.Data;
using MyBank.Model.Dto;
using MyBank.Repository.Interface;

namespace MyBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly MyBankDbContext myBankDbContext;
        private readonly IPersonRepository _personRepository;
        private readonly ILogger<PersonController> _logger;

        public PersonController(MyBankDbContext myBankDbContext,IPersonRepository personRepository,ILogger<PersonController> logger)
        {
            this.myBankDbContext = myBankDbContext;
            this._personRepository = personRepository;
            _logger = logger;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PersonDto>> AddPerson(PersonDto personDto)
        {
            try
            {
                var result = await _personRepository.AddPerson(personDto);
                _logger.LogInformation("Add Person.");
                return Ok(result);
            }catch (Exception ex)
            {
                _logger.LogError("Error while AddPerson in PersonController");
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("GetAllPersons")]
        public async Task<ActionResult<PersonDto>> GetAllPersons()
        {
            try
            {
                var result = await _personRepository.GetAllPersons();
                _logger.LogInformation("Get All Persons.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while GetAllPersons in PersonController");
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("GetByPersonId")]
        public async Task<ActionResult<PersonDto>> GetByPersonId(int id)
        {
            try
            {
                var result = await _personRepository.GetByPersonId(id);
                _logger.LogInformation("Get Person By Person ID");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while GetByPersonId in PersonController");
                throw ex;
            }
        }
    }
}
