using AutoMapper;
using Expense_Tracker.Data;
using Expense_Tracker.Model;
using Expense_Tracker.Model.Dto;
using Expense_Tracker.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IMapper _mapper;
        private readonly ExpenseTrackerDBContext expenseTrackerDBContext;

        public ExpenseRepository(IMapper mapper, ExpenseTrackerDBContext expenseTrackerDBContext)
        {
            _mapper = mapper;
            this.expenseTrackerDBContext = expenseTrackerDBContext;
        }

        public async Task<ExpenseDto> AddExpense(ExpenseDto expenseDto)
        {
            try
            {
                var data = _mapper.Map<Expense>(expenseDto);
                await expenseTrackerDBContext.Expense.AddAsync(data);
                await expenseTrackerDBContext.SaveChangesAsync();
                return _mapper.Map<ExpenseDto>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteExpenseById(int Id)
        {
            try
            {
                var data = expenseTrackerDBContext.Expense.FirstOrDefault(a => a.Id == Id);
                if (data == null) { return false; }
                expenseTrackerDBContext.Expense.Remove(data);
                expenseTrackerDBContext.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ExpenseDto>> GetExpenseByFilter(ExpenseFilterDto expenseFilterDto)
        {
            try
            {
                var data = await expenseTrackerDBContext.Expense.ToListAsync();
                if (data == null) { return null; }

                return _mapper.Map<List<ExpenseDto>>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ExpenseDto>> GetAllExpense()
        {
            try
            {
                var data = await expenseTrackerDBContext.Expense.ToListAsync();
                if(data == null) { return null; }

                return _mapper.Map<List<ExpenseDto>>(data);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExpenseDto> GetExpenseById(int Id)
        {
            var data = expenseTrackerDBContext.Expense.FirstOrDefault(a => a.Id == Id);
            if(data == null) { return null; }

            return _mapper.Map<ExpenseDto>(data);
        }
    }
}
