using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Groups.Core;
using SchoolOrganizer.Shared.Abstractions.Module;
using SchoolOrganizer.Shared.Infrastructure.Settings;

namespace SchoolOrganizer.Groups.Api;

public class GroupsModule : IModule
{
    public const string BasePath = "groups";
    public string Name { get; } = "Groups";

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        Console.WriteLine("Hello in groups module");
        services.AddCore(configuration);
    }

    public void Use(IApplicationBuilder app)
    {
        
        app.UseCore();
    }
}