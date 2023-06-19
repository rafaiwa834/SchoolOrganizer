using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Companies.Core.Entities;

namespace SchoolOrganizer.Companies.Core.DAL;

public class CompaniesDbContext: DbContext
{
    public DbSet<Company> Companies => Set<Company>();
    public CompaniesDbContext(DbContextOptions<CompaniesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.IsRelational()) modelBuilder.HasDefaultSchema("Companies");
        base.OnModelCreating(modelBuilder);
    }
}