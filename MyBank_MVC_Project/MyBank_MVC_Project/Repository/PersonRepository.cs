using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBank_MVC_Project.Data;
using MyBank_MVC_Project.Models.Account;
using MyBank_MVC_Project.Models.Dto;
using MyBank_MVC_Project.Repository.Interface;

namespace MyBank_MVC_Project.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyBankDbContext myBankDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonRepository> _logger;
        private readonly IAccountRepository accountRepository;

        public PersonRepository(MyBankDbContext myBankDbContext, IMapper mapper, ILogger<PersonRepository> logger, IAccountRepository accountRepository)
        {
            this.myBankDbContext = myBankDbContext;
            this._mapper = mapper;
            _logger = logger;
            this.accountRepository = accountRepository;
        }
        public async Task<PersonDto> AddPerson(PersonDto personDto)
        {
            using var DBtransaction = myBankDbContext.Database.BeginTransaction();
            try
            {
                var persondata = _mapper.Map<Person>(personDto);
                await myBankDbContext.Person.AddAsync(persondata);
                await myBankDbContext.SaveChangesAsync();
                var accoutstatus = accountRepository.AddAccount(personDto.AccountDto, persondata.Id);
                if (accoutstatus == null) { throw new Exception("Error wile add account"); }
                _logger.LogInformation("AddPerson Repository method Called...");

                DBtransaction.Commit();
                return _mapper.Map<PersonDto>(persondata);
            }
            catch (Exception ex)
            {
                await DBtransaction.RollbackAsync();
                _logger.LogError("Error while add a person in PersonRepository");
                throw ex;
            }
        }

        public async Task<List<PersonDto>> GetAllPersons()
        {
            try
            {
                var data = await myBankDbContext.Person.ToListAsync();
                if (data == null)
                {
                    _logger.LogWarning(204, "Not Found");
                    return null;
                }
                _logger.LogInformation("GetAllPersons Repository method Called...");
                return _mapper.Map<List<PersonDto>>(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while Get All Persons in PersonRepository");
                throw ex;
            }
        }

        public async Task<PersonDto> GetByPersonId(int id)
        {
            try
            {
                var data = await myBankDbContext.Person.FirstOrDefaultAsync(e => e.Id == id);
                if (data == null)
                {
                    _logger.LogWarning(204, "Not Found");
                    return null;
                }
                _logger.LogInformation("GetByPersonId Repository method Called...");
                return _mapper.Map<PersonDto>(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while GetByPersonId in PersonRepository");
                throw ex;
            }
        }
    }
}
