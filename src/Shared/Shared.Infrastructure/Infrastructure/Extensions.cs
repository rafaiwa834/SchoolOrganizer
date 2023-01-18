using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Infrastructure.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IList<Assembly> assemblies,
        IList<Module> modules)
    {

        return services;
    }
}