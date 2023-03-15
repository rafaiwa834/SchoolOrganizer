using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Commands;
using SchoolOrganizer.Shared.Abstractions.Context;
using SchoolOrganizer.Shared.Abstractions.Module;
using SchoolOrganizer.Shared.Abstractions.Queries;
using SchoolOrganizer.Shared.Abstractions.Time;
using SchoolOrganizer.Shared.Infrastructure.Auth;
using SchoolOrganizer.Shared.Infrastructure.Commands;
using SchoolOrganizer.Shared.Infrastructure.Context;
using SchoolOrganizer.Shared.Infrastructure.Queries;
using SchoolOrganizer.Shared.Infrastructure.Time;

namespace SchoolOrganizer.Shared.Infrastructure;

public static class InfrastructureModel
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration, List<Assembly> assemblies)
    {
        services.AddAuth(configuration);
        services.AddScoped<IClock, Clock>();
        services.AddHttpContextAccessor();
        services.AddSingleton<IUserContext, UserContext>();
        services.AddCommands(assemblies);
        services.AddQueries(assemblies);
        
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        
        return app;
    }
}