using Practice.Data;

namespace Practice.Repository
{
    public class AuthenticationRepository
    {
        private readonly AppDbContext appDbContext;

        public AuthenticationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public bool AuthenticateUser(string UserEmail, string Password)
        {
            //int rowcount = appDbContext.Users.Where(i => i.UserEmail == UserEmail && i.UserPassword == Password).Count();
            //int rowcount = appDbContext.EmployeeDetails()
            //if (rowcount == 0)
            //    return false;
            //else
            //{
                return true;
            //}
        }
    }
}
