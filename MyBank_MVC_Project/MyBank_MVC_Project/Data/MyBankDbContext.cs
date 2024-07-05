using Microsoft.EntityFrameworkCore;
using MyBank_MVC_Project.Models.Account;
using System;

namespace MyBank_MVC_Project.Data
{
    public class MyBankDbContext : DbContext
    {
        public MyBankDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
             .HasKey(e => e.Id);
            modelBuilder.Entity<Account>()
             .HasKey(e => e.Id);
            modelBuilder.Entity<MyTransactions>()
             .HasKey(e => e.Id);

            // Person to Account Relationship
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Person)
                .WithMany(p => p.Accounts)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Account to Transaction Relationship for FromAccount
            modelBuilder.Entity<MyTransactions>()
                .HasOne(t => t.FromAccount)
                .WithMany(a => a.TransactionsFrom)
                .HasForeignKey(t => t.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Account to Transaction Relationship for ToAccount
            modelBuilder.Entity<MyTransactions>()
                .HasOne(t => t.ToAccount)
                .WithMany(a => a.TransactionsTo)
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Person to Transaction Relationship
            modelBuilder.Entity<MyTransactions>()
                .HasOne(t => t.Person)
                .WithMany(p => p.Transaction)
                .HasForeignKey(t => t.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<MyTransactions> MyTransactions { get; set; }

    }
}
