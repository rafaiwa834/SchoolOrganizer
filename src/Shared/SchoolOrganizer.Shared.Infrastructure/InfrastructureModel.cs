using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Module;
using SchoolOrganizer.Shared.Infrastructure.Auth;

namespace SchoolOrganizer.Shared.Infrastructure;

public class InfrastructureModel : IModule
{
    public string Name { get; } = "Shared Infrastructure";

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuth();
    }

    public void Use(IApplicationBuilder app)
    {
    }
}