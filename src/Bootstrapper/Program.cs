using Bootstrapper;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var (assemblies, moduleAssemblies, modules) = AppInitializer.Initialize(builder);

Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);

foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    Console.WriteLine( "Assembly:   " + assembly.FullName);
}

Console.WriteLine("Base directory: " + AppDomain.CurrentDomain.BaseDirectory);
foreach (var directory in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll").ToList())
{
    Console.WriteLine("Driectory: " + directory);
}

