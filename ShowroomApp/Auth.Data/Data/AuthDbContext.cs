using System.Reflection;
using Auth.Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data.Data;

public class AuthDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public AuthDbContext()
    {
        
    }

    public AuthDbContext(DbContextOptions<AuthDbContext> ops) : base(ops)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
