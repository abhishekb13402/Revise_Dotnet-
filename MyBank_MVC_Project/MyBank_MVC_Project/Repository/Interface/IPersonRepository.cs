using MyBank_MVC_Project.Models.Dto;

namespace MyBank_MVC_Project.Repository.Interface
{
    public interface IPersonRepository
    {
        public Task<PersonDto> GetByPersonId(int id);
        public Task<List<PersonDto>> GetAllPersons();
        public Task<PersonDto> AddPerson(PersonDto personDto);
    }
}
