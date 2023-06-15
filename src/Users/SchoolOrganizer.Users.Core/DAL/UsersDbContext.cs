using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Users.Core.DAL.Configuration;
using SchoolOrganizer.Users.Core.Entities;

namespace SchoolOrganizer.Users.Core.DAL;

public class UsersDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.IsRelational()) modelBuilder.HasDefaultSchema("Users");
        modelBuilder.ApplyConfiguration(new UsersDbConfiguration());
        modelBuilder.SeedRoles();
        base.OnModelCreating(modelBuilder);
    }
}