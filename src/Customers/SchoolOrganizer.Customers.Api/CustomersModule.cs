using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Customers.Infrastructure;
using SchoolOrganizer.Shared.Abstractions.Module;

namespace SchoolOrganizer.Api;

public class CustomersModule: IModule
{
    internal const string BasePath = "customers";
    public string Name { get; } = "Customers";
    public void Use(IApplicationBuilder app)
    {
        
    }

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
    }
}