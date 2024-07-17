using Expense_Tracker.Model.Dto;
using Expense_Tracker.Repository;
using Expense_Tracker.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepositorye _personRepositorye;

        public PersonController(IPersonRepositorye personRepositorye)
        {
            _personRepositorye = personRepositorye;
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> AddExpense(PersonDto personDto)
        {
            try
            {
                if (personDto == null) { throw new ArgumentNullException(nameof(personDto)); }
                var result = await _personRepositorye.AddPerson(personDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllPerson")]
        public async Task<ActionResult<PersonDto>> GetAllExpense()
        {
            try
            {
                var result = await _personRepositorye.GetAllPerson();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<bool> DeletePersonById(int id)
        {
            try
            {
                var result = await _personRepositorye.DeletePersonById(id);
                if (result == true)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetPersonId")]
        public async Task<ActionResult<PersonDto>> GetExpenseById(int id)
        {
            try
            {
                var result = await _personRepositorye.GetPersonById(id);
                if (result == null)
                {
                    return null;
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
