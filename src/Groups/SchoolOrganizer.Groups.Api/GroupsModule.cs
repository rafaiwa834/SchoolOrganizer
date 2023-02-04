using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Groups.Core;
using SchoolOrganizer.Shared.Abstractions.Module;

namespace SchoolOrganizer.Groups.Api;

public class GroupsModule : IModule
{
    public const string BasePath = "groups";
    public string Name { get; } = "Groups";

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore();
    }

    public void Use(IApplicationBuilder app)
    {
    }
}