using System.Collections.Immutable;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SchoolOrganizer.Shared.Abstractions.Settings;

namespace SchoolOrganizer.Shared.Infrastructure.Settings;

public static class Configuration
{
    public static T GetOptions<T>(this IConfiguration configuration) where T : class, ISettings, new()
    {
        T results = new T();
        configuration.GetSection(T.SectionName).Bind(results);
        return results;
    }

    public static void ValidateOptions<T>(IServiceCollection services) where T : class, ISettings, new()
    {
        var result = services.AddOptions<T>()
            .BindConfiguration(T.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}