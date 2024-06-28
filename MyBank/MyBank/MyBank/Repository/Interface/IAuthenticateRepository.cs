using MyBank.Model.Dto;

namespace MyBank.Repository.Interface
{
    public interface IAuthenticateRepository
    {
        public bool AuthenticateUser(AuthDto authDto);
    }
}
