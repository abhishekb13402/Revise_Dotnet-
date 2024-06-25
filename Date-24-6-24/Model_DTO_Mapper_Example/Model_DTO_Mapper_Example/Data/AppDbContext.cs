using Microsoft.EntityFrameworkCore;
using Model_DTO_Mapper_Example.Model;

namespace Model_DTO_Mapper_Example.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
        }

        public DbSet<User> user { get; set; }
    }
}
