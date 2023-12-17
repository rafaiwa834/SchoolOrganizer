using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Module;

namespace ClassLibrary1;

public class NotificationsModule: IModule
{
    public const string BasePath = "notifications";
    public string Name { get; } = "Notifications";

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        
    }

    public void Use(IApplicationBuilder app)
    {
    }   
}