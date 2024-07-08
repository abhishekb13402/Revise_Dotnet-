using Microsoft.AspNetCore.Mvc;
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

        public IActionResult GenerateOTP(int accountno)
        {
            _accountRepository.GenerateOtp(accountno);
            return View();
        }

        public IActionResult VerifyOTP()
        {
            return View();
        }

        public IActionResult GetAllTransactions()
        {
            return View();
        }

        public IActionResult MakeTransaction()
        {
            return View();
        }
    }
}
