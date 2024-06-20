using JWTAuthentication.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<UserAuth> userAuth { get; set; }
        public DbSet<Student> student { get; set; }    
    }
}
