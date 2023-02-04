using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Module;

namespace SchoolOrganizer.Groups.Api;

public class GroupsModule: IModule
{
    public string Name { get; } = "Groups";
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        
    }

    public void Use(IApplicationBuilder app)
    {
    }
}