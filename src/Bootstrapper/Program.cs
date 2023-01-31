using Bootstrapper;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var (assemblies, moduleAssemblies, modules) = AppInitializer.Initialize(builder);

foreach (var module in modules)
{
    module.Register(builder.Services, builder.Configuration);
}
// Registry services

var app = builder.Build();

foreach (var module in modules)
{
    module.Use(app);
}


app.Run();

