using AutoMapper;
using FD_Service.Data;
using FD_Service.Model;
using FD_Service.Model.Dto;
using FD_Service.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MyBank.Model.Dto;

namespace FD_Service.Repository
{
    public class FDDetailsRepository : IFDDetailsRepository
    {
        private readonly FDDBContext fDDBContext;
        private readonly IMapper _mapper;

        public FDDetailsRepository(FDDBContext fDDBContext,IMapper mapper)
        {
            this.fDDBContext = fDDBContext;
            _mapper = mapper;
        }

        public async Task<FDDetailsDto> AddFDDetails(FDDetailsDto fDDetailsDto)
        {
            try
            {
                var data = _mapper.Map<FDDetails>(fDDetailsDto);
                await fDDBContext.FDDetails.AddAsync(data);
                await fDDBContext.SaveChangesAsync();
                return _mapper.Map<FDDetailsDto>(data);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FDDetailsDto>> GetAllFDDetails()
        {
            try
            {
                var data = await fDDBContext.FDDetails.ToListAsync();
                if (data == null)
                {
                    return null;
                }
                return _mapper.Map<List<FDDetailsDto>>(data);
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
