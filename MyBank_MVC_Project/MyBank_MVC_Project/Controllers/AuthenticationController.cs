using Microsoft.AspNetCore.Mvc;
using MyBank_MVC_Project.Models.Dto;
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

        public IActionResult AuthenticateUser(AuthDto authDto)
        {
            bool result = authenticateRepository.AuthenticateUser(authDto);
            if (!result) { return View("Index"); }
            return RedirectToAction("Index","Home",null);
        }
    }
}
