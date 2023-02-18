using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Infrastructure.Settings;

namespace SchoolOrganizer.Shared.Infrastructure.Postgres;

public static class Extensions
{
    public static void RegisterPostgres<T>(this IServiceCollection services, IConfiguration configuration) where T: DbContext
    {
        var postgresSettings = configuration.GetOptions<PostgresSettings>();
        services.AddDbContext<T>(options => options.UseNpgsql(postgresSettings.ConnectionString));
    }
}