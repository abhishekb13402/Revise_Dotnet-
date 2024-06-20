using JWTAuthentication.Model.Dto;

namespace JWTAuthentication.Repository
{
    public interface IAuthentication
    {
        public bool AuthenticateUser(AuthenticationDto authenticationDto);
    }
}
