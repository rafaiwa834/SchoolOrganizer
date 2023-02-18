using Microsoft.Extensions.Configuration;
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
}