using Microsoft.EntityFrameworkCore;
using Practice.Model;

namespace Practice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeEmail)
                .IsUnique(); // Create unique constraint on EmployeeEmail

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.employeeDetails)
                .WithOne(ed => ed.employee)
                .HasForeignKey<EmployeeDetails>(ed => ed.EmployeeId);  

            modelBuilder.Entity<EmployeeDetails>()
                .HasKey(ed => ed.Id);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.salaryDetails)
                .WithOne(sd => sd.Employee)
                .HasForeignKey<SalaryDetails>(sd => sd.EmployeeId);

            modelBuilder.Entity<SalaryDetails>()
                .HasKey(sd => sd.Id);

            modelBuilder.Entity<EmployeeAuth>()
                .HasKey(ed => ed.Id);

            modelBuilder.Entity<Employee>()
                 .HasOne(e => e.employeeAuth)
                 .WithOne(ea => ea.employee)
                 .HasForeignKey<EmployeeAuth>(ea => ea.EmployeeId);

        }


        public DbSet<Employee> employees { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<SalaryDetails> SalaryDetails { get; set; }
        public DbSet<EmployeeAuth> employeeAuths{ get; set; }
    }
}
