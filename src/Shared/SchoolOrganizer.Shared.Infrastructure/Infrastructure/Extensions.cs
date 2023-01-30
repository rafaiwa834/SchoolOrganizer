using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SchoolOrganizer.Shared.Infrastructure.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("version-1", new OpenApiInfo
            {
                Title = "School Organizer Api",
                Version = "v1"
            });
        });
        return services;
    }

    public static IApplicationBuilder UserInfrastructure(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseRouting();

        return app;
    }
}


