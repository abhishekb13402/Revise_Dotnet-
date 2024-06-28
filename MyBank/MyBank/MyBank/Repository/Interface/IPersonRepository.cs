using MyBank.Model.Dto;

namespace MyBank.Repository.Interface
{
    public interface IPersonRepository
    {
        public Task<PersonDto> GetByPersonId(int id);
        public Task<List<PersonDto>> GetAllPersons();
        public Task<PersonDto> AddPerson(PersonDto personDto);
    }
}
