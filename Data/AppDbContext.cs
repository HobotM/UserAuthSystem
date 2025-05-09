using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//Inherits from IdentityDbContext → gives you all tables (Users, Roles, Claims, etc.)
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
        {
        }

        // Add DbSet properties for your entities here
        // Example:
        // public DbSet<User> Users { get; set; }
    }
