using FD_Service.Model.Dto;

namespace FD_Service.Repository.Interface
{
    public interface IFDDetailsRepository
    {
        public Task<FDDetailsDto> AddFDDetails(FDDetailsDto fDDetailsDto);
        public Task<List<FDDetailsDto>> GetAllFDDetails();
    }
}
