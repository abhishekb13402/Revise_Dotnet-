using Microsoft.Identity.Client;
using MyBank.Model;
using MyBank.Model.Dto;

namespace MyBank.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<object> GetAccDetailsByAccountId(int id);
        Task<object> GetAllAccounts();
        Task<object> AddAccount(AccountDto accountDto);
        Task<object> AddTransaction(TransactionDto transactionDto);
        Task<object> GenerateOtp(int AccountNumber);
        public bool VerifyOtp(OTPDto oTPDto);
    }
}
