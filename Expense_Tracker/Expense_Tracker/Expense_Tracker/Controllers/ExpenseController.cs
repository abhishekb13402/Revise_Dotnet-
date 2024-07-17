using Expense_Tracker.Model.Dto;
using Expense_Tracker.Repository;
using Expense_Tracker.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseDto>> AddExpense(ExpenseDto expenseDto)
        {
            try
            {
                if (expenseDto == null) { throw new ArgumentNullException(nameof(expenseDto)); }
                var result = await _expenseRepository.AddExpense(expenseDto);
                return Ok(result);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetExpenseByFilter")]
        public async Task<ActionResult<ExpenseDto>> GetExpenseByFilter(ExpenseFilterDto expenseFilterDto)
        {
            try
            {
                var result = await _expenseRepository.GetExpenseByFilter(expenseFilterDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllExpense")]
        public async Task<ActionResult<ExpenseDto>> GetAllExpense()
        {
            try
            {
                var result = await _expenseRepository.GetAllExpense();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<bool> DeleteExpenseById(int id)
        {
            try
            {
                var result = await _expenseRepository.DeleteExpenseById(id);
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

        [HttpGet("GetExpenseById")]
        public async Task<ActionResult<CategoryDto>> GetExpenseById(int id)
        {
            try
            {
                var result = await _expenseRepository.GetExpenseById(id);
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
