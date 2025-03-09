using System.Reflection;
using FluentApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FluentApi.Data.Contexts;

public class ShowroomContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Salesman> Salesmen { get; set; }
    public DbSet<CarType> CarTypes { get; set; }
    public DbSet<FuelType> FuelTypes { get; set; }

    public ShowroomContext()
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
                .GetConnectionString("Default");
        
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}