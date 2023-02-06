using Bootstrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchoolOrganizer.Shared.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();

var (assemblies, moduleAssemblies, modules) = AppInitializer.Initialize(builder);

foreach (var module in modules)
{
    module.Register(builder.Services, builder.Configuration);
    builder.Services.AddControllers().AddApplicationPart(module.GetType().Assembly);
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


foreach (var module in modules)
{
    module.Use(app);
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolOrganizer");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();

app.MapGet("/", () => "Hello in SchoolOrganizer!");
app.UseEndpoints(endpoints =>
{
    app.MapControllers();
});

if (app.Environment.IsDevelopment())
    await app.Migrate(assemblies);

app.Run();

