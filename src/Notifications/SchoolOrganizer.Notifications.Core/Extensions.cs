using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolOrganizer.Notifications.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        // services.RegisterPostgres<GroupsDbContext>(configuration);
        // services.AddScoped<IGroupsService, GroupsesService>();
        // services.AddScoped<IGroupsModuleApi, GroupsModuleApi>();
        return services;
    }
}