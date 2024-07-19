using AutoMapper;
using Expense_Tracker.Model;
using Expense_Tracker.Model.Dto;

namespace Expense_Tracker
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configurationExpression =>
            {
                configurationExpression.CreateMap<Person, PersonDto>().ReverseMap();
                configurationExpression.CreateMap<Category, CategoryDto>().ReverseMap();
                configurationExpression.CreateMap<Expense,ExpenseDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
