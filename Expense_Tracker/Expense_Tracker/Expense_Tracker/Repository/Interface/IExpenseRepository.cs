using Expense_Tracker.Model.Dto;

namespace Expense_Tracker.Repository.Interface
{
    public interface IExpenseRepository
    {
        public Task<ExpenseDto> AddExpense(ExpenseDto expenseDto);
        public Task<List<ExpenseDto>> GetAllExpense();
        public Task<List<ExpenseDto>> GetExpenseByFilter(ExpenseFilterDto expenseFilterDto);
        public Task<ExpenseDto> GetExpenseById(int Id);
        public Task<bool> DeleteExpenseById(int Id);
    }
}
