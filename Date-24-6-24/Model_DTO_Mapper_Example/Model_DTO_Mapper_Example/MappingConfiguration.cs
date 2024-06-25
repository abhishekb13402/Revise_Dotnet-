using AutoMapper;
using Model_DTO_Mapper_Example.Model;
using Model_DTO_Mapper_Example.Model.Dto;

namespace Model_DTO_Mapper_Example
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configurationExpression =>
            {
                configurationExpression.CreateMap<User, UserDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
