using Expense_Tracker.Model.Dto;
using Expense_Tracker.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddCategory(CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null) { throw new Exception("Category Dto is null"); }
                var result = await _categoryRepository.AddCategory(categoryDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllCategory")]
        public async Task<ActionResult<CategoryDto>> GetAllCategory()
        {
            try
            {
                var result = await _categoryRepository.GetAllCategory();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<bool> DeleteCategoryById(int id)
        {
            try
            {
                var result = await _categoryRepository.DeleteCategoryById(id);
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

        [HttpGet("GetCategoryById")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            try
            {
                var result = await _categoryRepository.GetCategoryById(id);
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
