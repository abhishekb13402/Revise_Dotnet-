using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBank.Controllers;
using MyBank.Data;
using MyBank.Model;
using MyBank.Model.Dto;
using MyBank.Repository.Interface;
using System;

namespace MyBank.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyBankDbContext myBankDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonRepository> _logger;


        public PersonRepository(MyBankDbContext myBankDbContext,IMapper mapper,ILogger<PersonRepository> logger)
        {
            this.myBankDbContext = myBankDbContext;
            this._mapper = mapper;
            _logger = logger;
        }
        public async Task<PersonDto> AddPerson(PersonDto personDto)
        {
            try
            {
                var persondata = _mapper.Map<Person>(personDto);
                await myBankDbContext.Person.AddAsync(persondata);
                await myBankDbContext.SaveChangesAsync();
                _logger.LogInformation("AddPerson Repository method Called...");
                return _mapper.Map<PersonDto>(persondata);
            }
            catch (Exception ex)
            {
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
