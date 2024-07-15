using Microsoft.AspNetCore.Mvc;
using MyBank_MVC_Project.Repository.Interface;

namespace MyBank_MVC_Project.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticateRepository authenticateRepository;

        public AuthenticationController(IAuthenticateRepository authenticateRepository)
        {
            this.authenticateRepository = authenticateRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
