using Expense_Tracker.Model.Dto;

namespace Expense_Tracker.Repository.Interface
{
    public interface IPersonRepositorye
    {
        public Task<PersonDto> AddPerson(PersonDto personDto);
        public Task<List<PersonDto>> GetAllPerson();
        public Task<PersonDto> GetPersonById(int Id);
        public Task<bool> DeletePersonById(int Id);
    }
}
