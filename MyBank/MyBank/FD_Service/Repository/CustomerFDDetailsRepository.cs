using AutoMapper;
using FD_Service.Data;
using FD_Service.Model;
using FD_Service.Model.Dto;
using FD_Service.Repository.Interface;
using MyBank.Model;
using System.Reflection.Metadata.Ecma335;

namespace FD_Service.Repository
{
    public class CustomerFDDetailsRepository : ICustomerFDDetailsRepository
    {
        private readonly FDDBContext fDDBContext;
        private readonly IMapper _mapper;
        private readonly IMaturityAmountCalculation _maturityAmountCalculation;

        public CustomerFDDetailsRepository(FDDBContext fDDBContext, IMapper mapper, IMaturityAmountCalculation maturityAmountCalculation)
        {
            this.fDDBContext = fDDBContext;
            _mapper = mapper;
            _maturityAmountCalculation = maturityAmountCalculation;
        }

        public async Task<object> AddCustomerFDDetails(CustomerFDDetailsDto customerFDDetailsDto)
        {
            try
            {
                var data = _mapper.Map<CustomerFDDetails>(customerFDDetailsDto);
                bool isvalid = Datavalidations(customerFDDetailsDto);
                if (!isvalid)
                {
                    return "Error in Data \n 1. FD Amount must be Greater then 2000 \n 2. Date issue";
                }
                var maturityamount = await CalculateMaturityAmount(customerFDDetailsDto);
                data.MaturityAmount = maturityamount;
                data.EndDate =await CalculateMaturityEndDate(customerFDDetailsDto);
                data.TotalAmount = customerFDDetailsDto.Amount + maturityamount;
                await fDDBContext.CustomerFDDetails.AddAsync(data);
                await fDDBContext.SaveChangesAsync();
                return _mapper.Map<CustomerFDDetailsDto>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }

        private async Task<DateOnly> CalculateMaturityEndDate(CustomerFDDetailsDto customerFDDetailsDto)
        {
            try
            {
                var year = fDDBContext.FDDetails.Where(i=>i.FDPlan == customerFDDetailsDto.Plan).Select(y=>y.Year).FirstOrDefault();
                return customerFDDetailsDto.StartDate.AddYears((int)year);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<double> CalculateMaturityAmount(CustomerFDDetailsDto customerFDDetailsDto)
        {
            try
            {
                double amountCalculate;
                if (customerFDDetailsDto.Plan == "A")
                {
                    amountCalculate = await _maturityAmountCalculation.MaturityAmountCalculationForFirstYear(customerFDDetailsDto);
                }
                else if (customerFDDetailsDto.Plan == "B")
                {
                    amountCalculate = await _maturityAmountCalculation.MaturityAmountCalculationForTwoYear(customerFDDetailsDto);
                }
                else if (customerFDDetailsDto.Plan == "C")
                {
                    amountCalculate = await _maturityAmountCalculation.MaturityAmountCalculationForFiveYear(customerFDDetailsDto);
                }
                else
                {
                    throw new Exception("Invalid Plan");
                }
                return amountCalculate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Datavalidations(CustomerFDDetailsDto customerFDDetailsDto)
        {
            if (customerFDDetailsDto == null) { return false; }
            //if (customerFDDetailsDto.StartDate.Day > DateTime.Now.Day) { return false; }
            if (customerFDDetailsDto.StartDate < DateOnly.FromDateTime(DateTime.Now)) { return false; }
            if (customerFDDetailsDto.Amount < 2000) { return false; }
            return true;
        }

        public Task<List<CustomerFDDetailsDto>> GetAllCustomerFDDetails()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
    }
}
