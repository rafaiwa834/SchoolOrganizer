using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Customers.Infrastructure.DAL;
using SchoolOrganizer.Shared.Infrastructure.Postgres;

namespace SchoolOrganizer.Customers.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPostgres<CustomersDbContext>(configuration);
    }
}