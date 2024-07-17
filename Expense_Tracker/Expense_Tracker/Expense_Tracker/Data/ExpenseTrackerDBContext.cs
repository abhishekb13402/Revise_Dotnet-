using Expense_Tracker.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Expense_Tracker.Data
{
    public class ExpenseTrackerDBContext : DbContext
    {
        public ExpenseTrackerDBContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Person> Person { get; set; }
        //public DbSet<Auth> Auth{ get; set; }
        public DbSet<Expense> Expense{ get; set; }
        public DbSet<Category> Category{ get; set; }

    }
}
