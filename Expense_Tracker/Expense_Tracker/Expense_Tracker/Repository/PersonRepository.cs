using AutoMapper;
using Expense_Tracker.Data;
using Expense_Tracker.Model;
using Expense_Tracker.Model.Dto;
using Expense_Tracker.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository
{
    public class PersonRepository : IPersonRepositorye
    {
        private readonly IMapper _mapper;
        private readonly ExpenseTrackerDBContext expenseTrackerDBContext;

        public PersonRepository(IMapper mapper, ExpenseTrackerDBContext expenseTrackerDBContext)
        {
            _mapper = mapper;
            this.expenseTrackerDBContext = expenseTrackerDBContext;
        }

        public async Task<PersonDto> AddPerson(PersonDto personDto)
        {
            try
            {
                var data = _mapper.Map<Person>(personDto);
                await expenseTrackerDBContext.Person.AddAsync(data);
                await expenseTrackerDBContext.SaveChangesAsync();
                return _mapper.Map<PersonDto>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletePersonById(int Id)
        {
            try
            {
                var data = expenseTrackerDBContext.Person.FirstOrDefault(a => a.Id == Id);
                if (data == null) { return false; }
                expenseTrackerDBContext.Person.Remove(data);
                expenseTrackerDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PersonDto>> GetAllPerson()
        {
            try
            {
                var data = await expenseTrackerDBContext.Person.ToListAsync();
                if (data == null) { return null; }

                return _mapper.Map<List<PersonDto>>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonDto> GetPersonById(int Id)
        {
            var data = expenseTrackerDBContext.Person.FirstOrDefault(a => a.Id == Id);
            if (data == null) { return null; }

            return _mapper.Map<PersonDto>(data);
        }
    }
}
