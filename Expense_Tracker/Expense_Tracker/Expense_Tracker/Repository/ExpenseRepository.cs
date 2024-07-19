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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ExpenseDto>> GetExpenseByFilter(ExpenseFilterDto expenseFilterDto)
        {
            try
            {
                if (expenseFilterDto != null)
                {
                    var currentDate = DateTime.Now;
                    switch (expenseFilterDto.ExpenseType)
                    {

                        case ExpenseType.Pastweek:
                            var Pastweekdata = await expenseTrackerDBContext.Expense.Where(e => e.ExpenseDate >= DateOnly.FromDateTime(currentDate.AddDays(-7))).ToListAsync();
                            return _mapper.Map<List<ExpenseDto>>(Pastweekdata);


                        case ExpenseType.Lastmonth:
                            var Lastmonthdata = await expenseTrackerDBContext.Expense.Where(e => e.ExpenseDate >= DateOnly.FromDateTime(currentDate.AddMonths(-1))).ToListAsync();
                            return _mapper.Map<List<ExpenseDto>>(Lastmonthdata);


                        case ExpenseType.Last3months:
                            var Last3monthsdata = await expenseTrackerDBContext.Expense.Where(e => e.ExpenseDate >= DateOnly.FromDateTime(currentDate.AddMonths(-3))).ToListAsync();
                            return _mapper.Map<List<ExpenseDto>>(Last3monthsdata);

                        case ExpenseType.Custom:
                            var Customdata = await expenseTrackerDBContext.Expense.Where(e => e.ExpenseDate >= expenseFilterDto.StartDate && e.ExpenseDate <= expenseFilterDto.EndDate).ToListAsync();
                            return _mapper.Map<List<ExpenseDto>>(Customdata);


                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                return null;
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
                if (data == null) { return null; }

                return _mapper.Map<List<ExpenseDto>>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExpenseDto> GetExpenseById(int Id)
        {
            var data = expenseTrackerDBContext.Expense.FirstOrDefault(a => a.Id == Id);
            if (data == null) { return null; }

            return _mapper.Map<ExpenseDto>(data);
        }
    }
}
