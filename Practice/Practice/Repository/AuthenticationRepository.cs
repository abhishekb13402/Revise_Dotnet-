using Practice.Data;
using Practice.Model.Dto;

namespace Practice.Repository
{
    public class AuthenticationRepository : IAuthentication
    {
        private readonly AppDbContext appDbContext;

        public AuthenticationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public bool AuthenticateUser(AuthenticationDto authenticationDto)
        {
            int rowcount = appDbContext.employeeAuths.Where(i => i.EmployeeEmail == authenticationDto.Email && i.Password == authenticationDto.Password).Count();
            if (rowcount == 0)
                return false;
            else
            {
                return true;
            }
        }
    }
}
