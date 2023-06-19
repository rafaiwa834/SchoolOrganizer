using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Companies.Core;
using SchoolOrganizer.Shared.Abstractions.Module;

namespace SchoolOrganizer.Companies.Api;

public class CompaniesModule: IModule
{
    public string Name { get; } = "Companies";
    public const string BasePAth = "companies";
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore(configuration);
    }

    public void Use(IApplicationBuilder app)
    {
    }
}