using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Groups.Core.DAL;

namespace SchoolOrganizer.Groups.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddDbContext<GroupsDbContext>(
            options => options.UseNpgsql(""));
        
        return services;
    }
    
}