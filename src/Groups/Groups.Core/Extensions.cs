using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace Groups.Core;

[assembly: InternalsVisibleTo("SchoolOrganizer.Groups.Core")]
internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {


        return services;
    }
}