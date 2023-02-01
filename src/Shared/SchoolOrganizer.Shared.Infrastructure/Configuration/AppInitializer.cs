using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SchoolOrganizer.Shared.Abstractions.Module;

namespace SchoolOrganizer.Shared.Infrastructure.Configuration;

public static class AppInitializer
{
    private const string ModulePrefix = "SchoolOrganizer.";

    public static AppContext Initialize(WebApplicationBuilder builder)
    {
        var assemblies = AppDomain.CurrentDomain
            .GetAssemblies()
            .DistinctBy(x => x.Location)
            .ToDictionary(x => x.Location);

        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll").ToList();

        var moduleAssemblies = new List<Assembly>();
        foreach (var file in files)
        {
            if(!file.Contains(ModulePrefix)) continue;
            Console.WriteLine($"git plik: {file}");
            var moduleName = file.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries)
                .Last()
                .Split(".", StringSplitOptions.RemoveEmptyEntries)[1];
            var enabled = builder.Configuration.GetValue<bool>($"{moduleName}:ModuleEnabled");
            Console.WriteLine(enabled);
            if (!enabled) continue;
            Console.WriteLine("plik jest włączony");
            var assembly = AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName((file)));
            assemblies.TryAdd(assembly.Location, assembly);
            moduleAssemblies.Add(assembly);
        }

        var modules = assemblies
            .SelectMany(x => x.Value.TryGetTypes())
            .Where(x => typeof(IModule).IsAssignableFrom(x) && x.IsClass)
            .OrderBy(x => x.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();
        
        return new AppContext(assemblies.Select(x => x.Value).ToList(), moduleAssemblies, modules.ToHashSet());
    }
    
    private static Type[] TryGetTypes(this Assembly assembly)
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