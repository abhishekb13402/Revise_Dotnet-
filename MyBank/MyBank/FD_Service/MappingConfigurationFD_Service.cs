using AutoMapper;
using FD_Service.Model;
using FD_Service.Model.Dto;

namespace FD_Service
{
    public class MappingConfigurationFD_Service
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configurationExpression =>
            {
                configurationExpression.CreateMap<FDDetails, FDDetailsDto>().ReverseMap();
                configurationExpression.CreateMap<CustomerFDDetails, CustomerFDDetailsDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
