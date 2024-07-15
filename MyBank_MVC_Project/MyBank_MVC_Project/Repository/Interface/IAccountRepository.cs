using MyBank_MVC_Project.Models.Account;
using MyBank_MVC_Project.Models.Dto;

namespace MyBank_MVC_Project.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<object> GetAccDetailsByAccountId(int id);
        Task<object> GetAllAccounts();
        Task<object> AddAccount(AccountDto accountDto, int personid);
        Task<object> AddTransaction(TransactionDto transactionDto);
        Task<object> GenerateOtp(int AccountNumber);
        public bool VerifyOtp(OTPDto oTPDto);
        public List<MyTransactions> GetAllTransaction(int pageNumber, int pageSize);
    }
}
