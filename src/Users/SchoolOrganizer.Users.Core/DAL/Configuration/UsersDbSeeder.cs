using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Users.Core.Entities;

namespace SchoolOrganizer.Users.Core.DAL.Configuration;

public static class UsersDbSeeder
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "user"
            },
            new Role
            {
                Id = 2,
                Name = "admin"
            },
            new Role
            {
                Id = 3,
                Name = "owner"
            }
        );
    }
}