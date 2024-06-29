using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBank.Data;
using MyBank.Model.Dto;
using MyBank.Repository;
using MyBank.Repository.Interface;

namespace MyBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyBankDbContext myBankDbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<PersonController> _logger;

        public AccountController(MyBankDbContext myBankDbContext, IAccountRepository accountRepository, ILogger<PersonController> logger)
        {
            this.myBankDbContext = myBankDbContext;
            this._accountRepository = accountRepository;
            _logger = logger;
        }

        [HttpPost("GenerateOtp")]
        [Authorize]
        public async Task<object> GenerateOtp(int AccountNumber)
        {
            try
            {
                var otp = _accountRepository.GenerateOtp(AccountNumber);
                if (otp != null)
                {
                    return true;
                }
                else
                {
                    return "Generate OTP Error";
                }
            }
            catch (Exception ex)
            {
                return "OTP Generation Error";
            }
        }
        [HttpPost("VerifyOtp")]
        [Authorize]
        public async Task<object> VerifyOtp(OTPDto oTPDto)
        {
            try{
                var otp = _accountRepository.VerifyOtp(oTPDto);
                if (!otp)
                {
                    return "Invalid OTP";
                }
                else
                {
                    return true + "\n\nValid OTP You can Perform Transaction";
                }
            }catch (Exception ex)
            {
                return "OTP Verification Error";
            }
        }

        [Authorize]
        [HttpPost("AddAccount")]
        public async Task<object> AddAccount(AccountDto accountDto)
        {
            try
            {
                var result = await _accountRepository.AddAccount(accountDto);
                _logger.LogInformation("AddAccount.");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while AddAccount:{ex}");
                throw ex;
            }
        }

        [Authorize]
        [HttpPost("AddTransaction")]
        public async Task<ActionResult<object>> AddTransaction(TransactionDto transactionDto)
        {
            try
            {
                var result = await _accountRepository.AddTransaction(transactionDto);
                _logger.LogInformation($"{result}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while AddTransaction:{ex}");
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("GetAllAccounts")]
        public async Task<ActionResult<AccountDto>> GetAllAccounts()
        {
            try
            {
                var result = await _accountRepository.GetAllAccounts();
                _logger.LogInformation("GetAllAccounts");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while GetAllAccount:{ex}");
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("GetAccDetailsByAccountId")]
        public async Task<ActionResult<AccountDto>> GetAccDetailsByAccountId(int id)
        {
            try
            {
                var result = await _accountRepository.GetAccDetailsByAccountId(id);
                _logger.LogInformation($"{id} is {result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while GetAccDetailsByAccountId : {ex.Message}", ex);
                throw ex;
            }
        }
    }
}
