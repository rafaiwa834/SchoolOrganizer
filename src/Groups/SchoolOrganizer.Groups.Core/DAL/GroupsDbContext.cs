using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Groups.Core.DAL.Configuration;
using SchoolOrganizer.Groups.Core.Entities;

namespace SchoolOrganizer.Groups.Core.DAL;

public class GroupsDbContext : DbContext
{
    public DbSet<Group> Groups { get; set; }
    public GroupsDbContext(DbContextOptions<GroupsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.IsRelational()) modelBuilder.HasDefaultSchema("Groups");
        // new GroupsDbConfiguration().Configure(modelBuilder.Entity<Group>());
        modelBuilder.ApplyConfiguration(new GroupsDbConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}