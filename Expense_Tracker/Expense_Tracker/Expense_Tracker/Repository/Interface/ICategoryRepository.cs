using Expense_Tracker.Model.Dto;

namespace Expense_Tracker.Repository.Interface
{
    public interface ICategoryRepository
    {
        public Task<CategoryDto> AddCategory(CategoryDto categoryDto);
        public Task<List<CategoryDto>> GetAllCategory();
        public Task<CategoryDto> GetCategoryById(int Id);
        public Task<bool> DeleteCategoryById(int Id);
    }
}
