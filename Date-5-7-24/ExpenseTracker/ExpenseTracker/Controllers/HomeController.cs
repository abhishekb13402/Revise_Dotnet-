using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpenseDBContext context;

        public HomeController(ILogger<HomeController> logger, ExpenseDBContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        // write same name as a view
        public IActionResult Expenses()
        {
            var allExpenses = context.Expenses.ToList();
            var totalExpenses = allExpenses.Sum(x => x.Value);
            ViewBag.Expenses = totalExpenses;
            return View(allExpenses);
        }
        public IActionResult CreateEditExpense(int? id)
        {
            if (id != null)
            {
                var expenseInDb = context.Expenses.FirstOrDefault(expense => expense.Id == id);
                return View(expenseInDb);
            }
            return View();
        }
        public IActionResult DeleteExpense(int id)
        {
            var expenseInDb = context.Expenses.FirstOrDefault(expense => expense.Id == id);
            context.Expenses.Remove(expenseInDb);
            context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        //redirect to index view
        public IActionResult CreateEditExpenseForm(Expense expense)
        {
            if (expense.Id == 0)
            {
                context.Expenses.Add(expense);
            }
            else
            {
                context.Expenses.Update(expense);
            }

            context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
