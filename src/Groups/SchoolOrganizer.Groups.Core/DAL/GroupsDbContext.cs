using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Groups.Core.DAL.Configuration;
using SchoolOrganizer.Groups.Core.Entities;

namespace SchoolOrganizer.Groups.Core.DAL;

public class GroupsDbContext : DbContext
{
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Schedule> Schedules => Set<Schedule>();
    public GroupsDbContext(DbContextOptions<GroupsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.IsRelational()) modelBuilder.HasDefaultSchema("Groups");
        modelBuilder.ApplyConfiguration(new GroupsDbConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}