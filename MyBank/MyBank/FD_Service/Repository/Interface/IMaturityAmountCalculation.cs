using FD_Service.Model.Dto;

namespace FD_Service.Repository.Interface
{
    public interface IMaturityAmountCalculation
    {
        public Task<double> MaturityAmountCalculationForFirstYear(CustomerFDDetailsDto customerFDDetailsDto);
        public Task<double> MaturityAmountCalculationForTwoYear(CustomerFDDetailsDto customerFDDetailsDto);
        public Task<double> MaturityAmountCalculationForFiveYear(CustomerFDDetailsDto customerFDDetailsDto);
    }
}
