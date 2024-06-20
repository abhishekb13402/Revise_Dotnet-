using JWTAuthentication.Data;
using JWTAuthentication.Model.Dto;

namespace JWTAuthentication.Repository
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
            int rowcount = appDbContext.userAuth.Where(i => i.Email== authenticationDto.Email && i.Password == authenticationDto.Password).Count();
            if (rowcount == 0)
                return false;
            else
            {
                return true;
            }
        }
    }
}
