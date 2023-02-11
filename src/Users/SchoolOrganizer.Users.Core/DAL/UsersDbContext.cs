using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Users.Core.DAL.Configuration;
using SchoolOrganizer.Users.Core.Entities;

namespace SchoolOrganizer.Users.Core.DAL;

public class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.IsRelational()) modelBuilder.HasDefaultSchema("Users");
        modelBuilder.ApplyConfiguration(new UsersDbConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}