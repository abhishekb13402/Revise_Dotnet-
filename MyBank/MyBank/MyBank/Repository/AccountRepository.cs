using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBank.common.Mail;
using MyBank.Data;
using MyBank.Model;
using MyBank.Model.Dto;
using MyBank.Repository.Interface;

namespace MyBank.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyBankDbContext myBankDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountRepository> _logger;
        private readonly IMailService mailService;

        public AccountRepository(MyBankDbContext myBankDbContext, IMapper mapper, ILogger<AccountRepository> logger, IMailService mailService)
        {
            this.myBankDbContext = myBankDbContext;
            _mapper = mapper;
            _logger = logger;
            this.mailService = mailService;
        }
        public async Task<object> AddAccount(AccountDto accountDto)
        {
            try
            {
                if (accountDto == null)
                {
                    //_logger.LogWarning($"AccountDto information is Null");
                    return $"AccountDto information is Null";
                }

                if (accountDto.Balance < 0 || accountDto.Balance < 2000)
                {
                    //_logger.LogWarning($"ACCOUNT MINIMUM BALANCE MUST BE 2000 YOUR BALANCE IS = {accountDto.Balance} OR BALANCE NOT BE NEGATIVE");
                    return $"ACCOUNT MINIMUM BALANCE MUST BE 2000 YOUR BALANCE IS = {accountDto.Balance} OR BALANCE NOT BE NEGATIVE";
                }

                var existdata = myBankDbContext.Account
                    .Where(a => a.PersonId == accountDto.PersonId)
                    .Where(b => b.accounttype == accountDto.accounttype).Count();
                if (existdata > 0)
                {
                    //_logger.LogWarning($"ALREADY ACCOUNT IS CREATED WITH PersonId = {accountDto.PersonId} and AccountType = {accountDto.accounttype}");
                    return $"ALREADY ACCOUNT IS CREATED WITH PersonId = {accountDto.PersonId} and AccountType = {accountDto.accounttype}";
                }

                var accountdata = _mapper.Map<Account>(accountDto);
                await myBankDbContext.Account.AddAsync(accountdata);
                await myBankDbContext.SaveChangesAsync();
                _logger.LogInformation("Successfully AddAccount");
                return _mapper.Map<AccountDto>(accountdata);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<object> AddTransaction(TransactionDto transactionDto)
        {
            try
            {
                if (transactionDto == null)
                {
                    //_logger.LogWarning("EMPTY FIELDS.");
                    return "EMPTY FIELDS.";
                }
                else if (!ValidateParameters(transactionDto))
                {
                    //_logger.LogWarning("PLEASE INPUT VALID PARAMETERS");
                    return "PLEASE INPUT VALID PARAMETERS";
                }
                if (transactionDto.transactionType == TransactionType.Deposit)
                {
                    return await TransactionTypeDeposit(transactionDto);
                }
                else if (transactionDto.transactionType == TransactionType.Withdraw)
                {
                    return await TransactionTypeWithdraw(transactionDto);
                }
                else if (transactionDto.transactionType == TransactionType.FundsTransfer)
                {
                    return await TransactionTypeFundsTransfer(transactionDto);
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool ValidateParameters(TransactionDto transactionDto)
        {
            try
            {
                if (transactionDto.Amount <= 0)
                {
                    return false;
                }

                if (transactionDto.FromAccountId > 0)
                {
                    if (!ExistAccountId(transactionDto.FromAccountId))
                    {
                        return false;
                    }
                }

                if (transactionDto.ToAccountId > 0)
                {
                    if (!ExistAccountId(transactionDto.ToAccountId))
                    {
                        return false;
                    }
                }

                transactionDto.Amount = Math.Round(transactionDto.Amount, 2);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool ExistAccountId(int accountId)
        {
            return myBankDbContext.Account
                .Any(i => i.Id == accountId);
        }

        private async Task<bool> TransactionTypeFundsTransfer(TransactionDto transactionDto)
        {
            using var DBtransaction = myBankDbContext.Database.BeginTransaction();

            try
            {
                var fromAccount = await myBankDbContext.Account.FirstOrDefaultAsync(a => a.Id == transactionDto.FromAccountId);
                var toAccount = await myBankDbContext.Account.FirstOrDefaultAsync(a => a.Id == transactionDto.ToAccountId);

                if (fromAccount == null || toAccount == null)
                {
                    _logger.LogError("Invalid Account Details.");
                    throw new Exception("Invalid Account Details.");
                }

                if (fromAccount.Balance < transactionDto.Amount)
                {
                    _logger.LogError("Insufficient balance.");
                    throw new Exception("Insufficient balance.");
                }

                var currentbalancefromAccount = fromAccount.Balance -= transactionDto.Amount;
                if (currentbalancefromAccount < 2000)
                {
                    _logger.LogError("Minimum Maintain Balance is Rs 2000.");
                    throw new Exception("Minimum Maintain Balance is Rs 2000.");
                }
                var currentbalancetoAccount = toAccount.Balance += transactionDto.Amount;

                var transaction = _mapper.Map<MyTransactions>(transactionDto);
                transaction.TimeStamp = DateTime.UtcNow; 
                await myBankDbContext.MyTransactions.AddAsync(transaction);
                await myBankDbContext.SaveChangesAsync();

                var toEmail = (from a in myBankDbContext.Account
                               join p in myBankDbContext.Person on a.PersonId equals p.Id
                               where a.Id == transactionDto.ToAccountId
                               select p.Email).FirstOrDefault();

                var fromEmail = (from a in myBankDbContext.Account
                               join p in myBankDbContext.Person on a.PersonId equals p.Id
                               where a.Id == transactionDto.FromAccountId
                               select p.Email).FirstOrDefault();

                var emailstatus = await mailService.SendFundTransferEmailAsync(toEmail, fromEmail, transactionDto.Amount, fromAccount.Id);
                if (!emailstatus)
                { throw new Exception("Email sending err"); }

                _logger.LogInformation($"Transaction FundFransfer done successfull : {transaction}");
                
                DBtransaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                await DBtransaction.RollbackAsync();
                _logger.LogError($"Rollback : {ex.Message}", ex);
                return false;
            }

        }

        private async Task<bool> TransactionTypeWithdraw(TransactionDto transactionDto)
        {
            using var DBtransaction = myBankDbContext.Database.BeginTransaction();
            try
            {
                var fromAccount = await myBankDbContext.Account.FirstOrDefaultAsync(a => a.Id == transactionDto.FromAccountId);

                if (fromAccount.Balance < transactionDto.Amount)
                {
                    _logger.LogWarning("Insufficient balance.");
                    throw new Exception("Insufficient balance.");
                }

                var currentbalance = fromAccount.Balance -= transactionDto.Amount;

                if (currentbalance < 2000)
                {
                    _logger.LogWarning("Minimum Maintain Balance is Rs 2000.");
                    throw new Exception("Minimum Maintain Balance is Rs 2000.");
                }

                var transaction = _mapper.Map<MyTransactions>(transactionDto);
                transaction.TimeStamp = DateTime.UtcNow; 
                await myBankDbContext.MyTransactions.AddAsync(transaction);
                await myBankDbContext.SaveChangesAsync();

                var fromEmail = (from a in myBankDbContext.Account
                               join p in myBankDbContext.Person on a.PersonId equals p.Id
                               where a.Id == transactionDto.ToAccountId
                               select p.Email).FirstOrDefault();

                var emailstatus = await mailService.SendWithdrawEmailAsync(fromEmail, transactionDto.Amount, fromAccount.Id);
                if (!emailstatus)
                { throw new Exception("Email sending err"); }
                _logger.LogInformation($"Transaction Withdraw done successfull : {transaction}");
                DBtransaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                await DBtransaction.RollbackAsync();
                _logger.LogError($"Rollback : {ex.Message}", ex);
                return false;
            }
        }

        private async Task<bool> TransactionTypeDeposit(TransactionDto transactionDto)
        {
            using var DBtransaction = myBankDbContext.Database.BeginTransaction();
            try
            {
                var toAccount = await myBankDbContext.Account.FirstOrDefaultAsync(a => a.Id == transactionDto.ToAccountId);
                if (toAccount == null)
                {
                    return false;
                }
                toAccount.Balance += transactionDto.Amount;

                var transaction = _mapper.Map<MyTransactions>(transactionDto);
                transaction.TimeStamp = DateTime.UtcNow;
                await myBankDbContext.MyTransactions.AddAsync(transaction);
                await myBankDbContext.SaveChangesAsync();

                _logger.LogInformation($"Transaction Deposit done successfull : {transaction}");

                var toEmail = (from a in myBankDbContext.Account
                               join p in myBankDbContext.Person on a.PersonId equals p.Id
                               where a.Id == transactionDto.ToAccountId
                               select p.Email).FirstOrDefault();

                var emailstatus = await mailService.SendDepositEmailAsync(toEmail, transactionDto.Amount, toAccount.Id);
                if(!emailstatus)
                { throw new Exception("Email sending err"); }
                DBtransaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                await DBtransaction.RollbackAsync();
                _logger.LogError($"Rollback : {ex.Message}", ex);
                return false;
            }
        }

        public async Task<object> GetAccDetailsByAccountId(int id)
        {
            try
            {
                var data = await myBankDbContext.Account
                    .Include(a => a.Person)
                    .FirstOrDefaultAsync(a => a.Id == id);
                if (data == null)
                {
                    return $"ACCOUNT NUMBER IS NOT VALID";
                }
                var accountDetailsDto = new AccoutPersonDetailsDto
                {
                    Account = _mapper.Map<AccountDto>(data),
                    Person = _mapper.Map<PersonDto>(data.Person)
                };
                return accountDetailsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occure in GetAccDetailsByAccountId");
                throw ex;
            }
        }

        public async Task<object> GetAllAccounts()
        {
            try
            {
                var data = await myBankDbContext.Account.ToListAsync();
                if (data == null)
                {
                    return "NO RECORD WAS FOUND.";
                }
                return _mapper.Map<List<AccountDto>>(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occure in GetAllAccounts");
                throw ex;
            }
        }

        public async Task<object> GenerateOtp(int AccountNumber)
        {
            var user = myBankDbContext.Account
                .Include(a => a.Person)
                .FirstOrDefault(Account => Account.Id == AccountNumber);
            if (user == null)
            { return false; }
            string data = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
            var charotp = new char[6];
            Random random = new Random();
            for(int i = 0; i < charotp.Length; i++)
            {
                charotp[i]= data[random.Next(data.Length)];
            }
            string otp = new string(charotp);

            //add in account tbl
            var emailstatus = await mailService.SendGenerateOtpEmailAsync(otp, user.Person.Email);
            if (!emailstatus)
            { throw new Exception("Email sending err"); }
            return true;
        }

        public async Task<object> VerifyOtp(AccountDto accountDto)
        {
            return true;
        }
    }
}
