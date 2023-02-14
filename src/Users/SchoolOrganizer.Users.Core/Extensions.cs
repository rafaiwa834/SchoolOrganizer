using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Infrastructure.Settings;
using SchoolOrganizer.Users.Core.DAL;
using SchoolOrganizer.Users.Core.Services;

namespace SchoolOrganizer.Users.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        var postgresSettings = configuration.GetOptions<PostgresSettings>();
        services.AddDbContext<UsersDbContext>(options => options.UseNpgsql(postgresSettings.ConnectionString));
        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}