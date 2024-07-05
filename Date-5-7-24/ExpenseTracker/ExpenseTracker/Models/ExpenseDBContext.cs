using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    public class ExpenseDBContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public ExpenseDBContext(DbContextOptions options) : base(options)
        {
         
        }
    }
}
