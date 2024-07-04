using AutoMapper;
using FD_Service.Data;
using FD_Service.Model;
using FD_Service.Model.Dto;
using FD_Service.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MyBank.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FD_Service.Repository
{
    public class MaturityAmountCalculationRepository : IMaturityAmountCalculation
    {
        private readonly FDDBContext fDDBContext;
        private readonly IMapper mapper;

        public MaturityAmountCalculationRepository(FDDBContext fDDBContext, IMapper mapper)
        {
            this.fDDBContext = fDDBContext;
            this.mapper = mapper;
        }

        public Task<double> MaturityAmountCalculationForFirstYear(CustomerFDDetailsDto customerFDDetailsDto)
        {
            try
            {
                var fdDetail = fDDBContext.FDDetails.FirstOrDefault(i => i.FDPlan == customerFDDetailsDto.Plan);

                if (fdDetail == null)
                {
                    throw new Exception("FD Plan not found");
                }

                var time = fdDetail.Year;
                var rate = (double)fdDetail.Percentage;
                var interest = (customerFDDetailsDto.Amount * rate * time) / 100;

                return Task.FromResult(interest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<double> MaturityAmountCalculationForFiveYear(CustomerFDDetailsDto customerFDDetailsDto)
        {
            try
            {
                return CalculateCompoundInterest(customerFDDetailsDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Task<double> CalculateCompoundInterest(CustomerFDDetailsDto customerFDDetailsDto)
        {
            try
            {
                var fdDetail = fDDBContext.FDDetails.FirstOrDefault(i => i.FDPlan == customerFDDetailsDto.Plan);

                if (fdDetail == null)
                {
                    throw new Exception("FD Plan not found");
                }

                var principal = customerFDDetailsDto.Amount;
                var interestRate = (double)fdDetail.Percentage / 100;
                var years = (double)fdDetail.Year;
                var compoundingPeriodsPerYear = years;

                var maturityAmount = principal * Math.Pow((1 + (interestRate / compoundingPeriodsPerYear)), compoundingPeriodsPerYear * years);
                var roundedAmount = Math.Round(maturityAmount, 2);
                return Task.FromResult(roundedAmount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<double> MaturityAmountCalculationForTwoYear(CustomerFDDetailsDto customerFDDetailsDto)
        {
            try
            {
                return CalculateCompoundInterest(customerFDDetailsDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
