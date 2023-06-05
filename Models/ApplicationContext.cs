using Microsoft.EntityFrameworkCore;

namespace TrialLoginAndRegistrationWeb.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Clothes> Clothes { get; set; } = null!;
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) 
        { 
            Database.EnsureCreated();
        }
        public DbSet<Order> Orders { get; set; } = null!;
    }
}
