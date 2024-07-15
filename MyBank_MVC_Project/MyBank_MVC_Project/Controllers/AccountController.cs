using Microsoft.AspNetCore.Mvc;
using MyBank_MVC_Project.Models.Dto;
using MyBank_MVC_Project.Repository.Interface;

namespace MyBank_MVC_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GenerateOTP(int accountno)
        {
            var result = await _accountRepository.GenerateOtp(accountno);
          
            if (result is true)
            {
                ViewData["SuccessMessage"] = "OTP has been generated and sent to your email.";
            }
            else
            {
                ViewData["ErrorMessage"] = "An unexpected error occurred.";
            }

            return View("Index");
        }
       
        public IActionResult VerifyOTP(OTPDto oTPDto)
        {
            var result = _accountRepository.VerifyOtp(oTPDto);

            if (result)
            {
                ViewData["SuccessMessage"] = "OTP has been Verify.";
            }
            else
            {
                ViewData["ErrorMessage"] = "An unexpected error occurred.";
            }

            return View("Index");

        }

        public IActionResult GetAllTransactions(int pageNumber, int pageSize)
        {
            var data = _accountRepository.GetAllTransaction(pageNumber, pageSize);
            return View(data);
        }

        public IActionResult MakeTransaction(TransactionDto transactionDto)
        {
            var result = _accountRepository.AddTransaction(transactionDto);

            if (result == null)
            {
                ViewData["ErrorMessage"] = "An unexpected error occurred.";
                return View("Index");
            }
            return View();
        }
    }
}
