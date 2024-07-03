using FD_Service.Model;
using Microsoft.EntityFrameworkCore;
using MyBank.Model;

namespace FD_Service.Data
{
    public class FDDBContext : DbContext
    {
        public FDDBContext(DbContextOptions<FDDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FDDetails>()
             .HasKey(e => e.Id);
            modelBuilder.Entity<CustomerFDDetails>()
             .HasKey(e => e.Id);
        }
        public DbSet<FDDetails> FDDetails { get; set; }
        public DbSet<CustomerFDDetails> CustomerFDDetails { get; set; }
    }
}
