using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Module;
using SchoolOrganizer.Users.Core;

namespace SchoolOrganizer.Users.Api;

public class UsersModule : IModule
{
    public const string BasePath = "users";
    public string Name { get; } = "Users";

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore(configuration);
    }

    public void Use(IApplicationBuilder app)
    {
    }
}