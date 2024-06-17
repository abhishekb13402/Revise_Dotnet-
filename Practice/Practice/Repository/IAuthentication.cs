using Practice.Model.Dto;

namespace Practice.Repository
{
    public interface IAuthentication
    {
        public bool AuthenticateUser(AuthenticationDto authenticationDto);
    }
}
