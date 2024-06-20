using AutoMapper;
using JWTAuthentication.Model;
using JWTAuthentication.Model.Dto;

namespace JWTAuthentication
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configurationExpression =>
            {
                configurationExpression.CreateMap<UserAuth, AuthenticationDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
