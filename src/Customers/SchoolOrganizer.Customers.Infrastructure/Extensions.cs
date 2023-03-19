using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Customers.Domain.Repositories;
using SchoolOrganizer.Customers.Infrastructure.DAL;
using SchoolOrganizer.Customers.Infrastructure.DAL.Repositories;
using SchoolOrganizer.Shared.Infrastructure.Postgres;

namespace SchoolOrganizer.Customers.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPostgres<CustomersDbContext>(configuration);
        services.AddScoped<IParentsRepository, ParentRepository>();
        services.AddScoped<IChildrenRepository, ChildrenRepository>();
    }
}