using MyBank_MVC_Project.Models.Dto;

namespace MyBank_MVC_Project.Repository.Interface
{
    public interface IAuthenticateRepository
    {
        public bool AuthenticateUser(AuthDto authDto);

    }
}
