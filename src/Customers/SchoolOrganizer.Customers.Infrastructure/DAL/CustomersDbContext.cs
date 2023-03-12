using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Customers.Domain.Entities;

namespace SchoolOrganizer.Customers.Infrastructure.DAL;

public class CustomersDbContext: DbContext
{
    public DbSet<Parent> Parents => Set<Parent>();
    public DbSet<Child> Children => Set<Child>();
    
    public CustomersDbContext(DbContextOptions<CustomersDbContext> options): base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.IsRelational()) modelBuilder.HasDefaultSchema("Customers");
        // modelBuilder.ApplyConfiguration(new UsersDbConfiguration());
        base.OnModelCreating(modelBuilder);
    }}