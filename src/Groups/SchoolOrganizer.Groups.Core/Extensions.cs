using System.Runtime.CompilerServices;
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
        // var postgresSettings = new PostgresSettings();
        // configuration.GetSection("Postgres").Bind(postgresSettings);
        var postgresSettings = configuration.GetOptions<PostgresSettings>();

        Console.WriteLine(postgresSettings.ConnectionString);
        services.AddDbContext<GroupsDbContext>(
            options => options.UseNpgsql(postgresSettings.ConnectionString));
        
        return services;
    }
    
}