using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Companies.Core.DAL;
using SchoolOrganizer.Shared.Infrastructure.Postgres;

namespace SchoolOrganizer.Companies.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPostgres<CompaniesDbContext>(configuration);
        return services;
    }
}