using AutoMapper;
using MyBank.Model;
using MyBank.Model.Dto;

namespace MyBank
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configurationExpression =>
            {
                configurationExpression.CreateMap<Person, PersonDto>().ReverseMap();
                configurationExpression.CreateMap<Account, AccountDto>().ReverseMap();

                configurationExpression.CreateMap<Person, AccoutPersonDetailsDto>().ReverseMap();

                configurationExpression.CreateMap<Account, AccoutPersonDetailsDto>()
                   .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src))
                   .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

                configurationExpression.CreateMap<MyTransactions, TransactionDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
