using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Queries;

namespace SchoolOrganizer.Shared.Infrastructure.Queries;

public static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        services.Scan(x =>
            x.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );
        return services;
    }
}