using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Infrastructure.Postgres;
using SchoolOrganizer.Shared.Infrastructure.Settings;
using SchoolOrganizer.Users.Core.DAL;
using SchoolOrganizer.Users.Core.Services;

namespace SchoolOrganizer.Users.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IIdentityService, IdentityService>();
        services.RegisterPostgres<UsersDbContext>(configuration);
        return services;
    }
}