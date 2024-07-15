using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBank_MVC_Project.Models.Account;
using MyBank_MVC_Project.Models.Dto;
using MyBank_MVC_Project.Repository.Interface;

namespace MyBank_MVC_Project.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _personRepository.GetAllPersons();
            return View(data);
        }
        public IActionResult AddPersonForm()
        {
            ViewBag.AccountTypes = new SelectList(Enum.GetValues(typeof(AccountType)).Cast<AccountType>());
            return View(new PersonDto());
        }
        public async Task<IActionResult> AddPerson(PersonDto personDto)
        {
            await _personRepository.AddPerson(personDto);
            return RedirectToAction("Index");
        }
    }
}
