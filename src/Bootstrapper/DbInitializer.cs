using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Infrastructure.Configuration;

namespace Bootstrapper;

internal static class DbInitializer
{
    public static async Task Migrate(this WebApplication app ,IEnumerable<Assembly> assemblies)
    {
        using var scope = app.Services.CreateScope();
        var servicesProvider = scope.ServiceProvider;
        var context = GetContext(assemblies)
            .Select(x => servicesProvider.GetRequiredService(x))
            .Where(x => x is DbContext)
            .Cast<DbContext>()
            .ToList();

        // await context.FirstOrDefault()!.Database.EnsureDeletedAsync();
        
        // var migrations = context.Select(x => x.Database.MigrateAsync());
        // await Task.WhenAll(migrations);
        var migration = context.FirstOrDefault();
        await migration.Database.MigrateAsync();
    }

    public static IEnumerable<Type> GetContext(IEnumerable<Assembly> assemblies)
    {
        return assemblies.SelectMany(x => x.TryGetTypes())
            .Where(x => typeof(DbContext).IsAssignableFrom(x)
                        && !x.IsInterface && x != typeof(DbContext));
    }
}