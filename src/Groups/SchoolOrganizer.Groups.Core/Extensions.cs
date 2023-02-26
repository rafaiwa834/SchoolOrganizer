using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Groups.Core.DAL;
using SchoolOrganizer.Groups.Core.Services;
using SchoolOrganizer.Shared.Infrastructure.Postgres;
using SchoolOrganizer.Shared.Infrastructure.Settings;

namespace SchoolOrganizer.Groups.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPostgres<GroupsDbContext>(configuration);
        services.AddScoped<IGroupService, GroupsService>();
        return services;
    }
}