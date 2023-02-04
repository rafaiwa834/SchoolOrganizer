using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SchoolOrganizer.Shared.Infrastructure.Configuration;

public static class Extensions
{
    public static void ConfigureModules(this IHostBuilder builder) =>
        builder.ConfigureAppConfiguration((ctx, cfg) =>
        {
            foreach (var settings in ctx.GetSettings("*"))
            {
                cfg.AddJsonFile(settings);
            }
        });

    private static IEnumerable<string> GetSettings(this HostBuilderContext ctx, string pattern) =>
        Directory.EnumerateFiles(ctx.HostingEnvironment.ContentRootPath.Split("src").First(),
            $"module.{pattern}.json", SearchOption.AllDirectories);

    public static Type[] TryGetTypes(this Assembly assembly)
    {
        Type[] types;
        try
        {
            types = assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
            types = e.Types!;
        }
        return types;
    }
}