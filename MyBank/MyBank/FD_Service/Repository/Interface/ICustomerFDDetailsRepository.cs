using FD_Service.Model.Dto;

namespace FD_Service.Repository.Interface
{
    public interface ICustomerFDDetailsRepository
    {
        public Task<object> AddCustomerFDDetails(CustomerFDDetailsDto customerFDDetailsDto);
        public Task<List<CustomerFDDetailsDto>> GetAllCustomerFDDetails();
    }
}
