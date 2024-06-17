using AutoMapper;
using Practice.Model;
using Practice.Model.Dto;

namespace Practice
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configurationExpression =>
            {
                configurationExpression.CreateMap<EmployeeAuth, AuthenticationDto>().ReverseMap();

                configurationExpression.CreateMap<Employee, EmployeeDto>()
                     .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.employeeDetails))
                     .ReverseMap();
                configurationExpression.CreateMap<EmployeeDetails, EmployeeDetailsDto>().ReverseMap();
                configurationExpression.CreateMap<EmployeeDetails, EmployeeDto>().ReverseMap();

                configurationExpression.CreateMap<EmployeeSalaryDto, SalaryDetails>().ReverseMap();
                configurationExpression.CreateMap<EmployeeSalaryDto, EmployeeDetails>().ReverseMap();

            });

            return mappingConfig;
        }
    }
}
