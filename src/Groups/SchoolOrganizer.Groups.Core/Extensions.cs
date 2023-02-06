using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Groups.Core.DAL;
using SchoolOrganizer.Shared.Infrastructure.Settings;

namespace SchoolOrganizer.Groups.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        var postgresSettings = configuration.GetOptions<PostgresSettings>();
        services.AddDbContext<GroupsDbContext>(
            options => options.UseNpgsql(postgresSettings.ConnectionString));
        
        return services;
    }

    public static IApplicationBuilder UseCore(this IApplicationBuilder app)
    {
        return app;
    }

}