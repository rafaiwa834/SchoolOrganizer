using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Shared.Infrastructure.Commands;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.Scan(x =>
            x.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );
        return services;
    }
}