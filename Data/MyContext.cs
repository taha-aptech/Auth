using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> tbl_users { get; set; }
        public DbSet<Role> tbl_role { get; set; } 
    }
    
  
    }
