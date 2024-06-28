using MyBank.Data;
using MyBank.Model.Dto;
using MyBank.Repository.Interface;
using System;

namespace MyBank.Repository
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly MyBankDbContext myBankDbContext;

        public AuthenticateRepository(MyBankDbContext myBankDbContext)
        {
            this.myBankDbContext = myBankDbContext;
        }
        public bool AuthenticateUser(AuthDto authDto)
        {
            try
            {
                int rowcount = myBankDbContext.Person.Where(i => i.Email == authDto.Email && i.Password == authDto.Password).Count();
                if (rowcount != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
