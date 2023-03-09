using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Customers.Domain.Entities;

namespace SchoolOrganizer.Customers.Intrastructure.DAL;

public class CustomersDbContext: DbContext
{
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Child> Children { get; set; }
    
    public CustomersDbContext(DbContextOptions<CustomersDbContext> options): base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.IsRelational()) modelBuilder.HasDefaultSchema("Customers");
        // modelBuilder.ApplyConfiguration(new UsersDbConfiguration());
        base.OnModelCreating(modelBuilder);
    }}