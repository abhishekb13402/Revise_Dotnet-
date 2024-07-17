using AutoMapper;
using Expense_Tracker.Data;
using Expense_Tracker.Model;
using Expense_Tracker.Model.Dto;
using Expense_Tracker.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;
        private readonly ExpenseTrackerDBContext expenseTrackerDBContext;

        public CategoryRepository(IMapper mapper, ExpenseTrackerDBContext expenseTrackerDBContext)
        {
            _mapper = mapper;
            this.expenseTrackerDBContext = expenseTrackerDBContext;
        }

        public async Task<CategoryDto> AddCategory(CategoryDto categoryDto)
        {
            try
            {
                var data = _mapper.Map<Category>(categoryDto);
                await expenseTrackerDBContext.Category.AddAsync(data);
                await expenseTrackerDBContext.SaveChangesAsync();
                return _mapper.Map<CategoryDto>(data);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteCategoryById(int Id)
        {
            try
            {
                var data = expenseTrackerDBContext.Category.FirstOrDefault(a => a.Id == Id);
                if (data == null) { return false; }
                expenseTrackerDBContext.Category.Remove(data);
                expenseTrackerDBContext.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryDto>> GetAllCategory()
        {
            try
            {
                var data = await expenseTrackerDBContext.Category.ToListAsync();
                if (data == null) { return null; }

                return _mapper.Map<List<CategoryDto>>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoryDto> GetCategoryById(int Id)
        {
            var data = expenseTrackerDBContext.Category.FirstOrDefault(a => a.Id == Id);
            if(data == null) { return null; }

            return _mapper.Map<CategoryDto>(data);
        }
    }
}
