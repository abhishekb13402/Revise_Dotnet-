using MyBank_MVC_Project.Data;
using MyBank_MVC_Project.Models.Dto;
using MyBank_MVC_Project.Repository.Interface;

namespace MyBank_MVC_Project.Repository
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
