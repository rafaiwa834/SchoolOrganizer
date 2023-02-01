using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SchoolOrganizer.Shared.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

var (assemblies, moduleAssemblies, modules) = AppInitializer.Initialize(builder);

foreach (var module in modules)
{
    Console.WriteLine(module.Name);
}
foreach (var module in moduleAssemblies)
{
    Console.WriteLine(module.FullName);
}
Console.WriteLine("test");

foreach (var module in modules)
{
    module.Register(builder.Services, builder.Configuration);
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

app.UseSwagger();

foreach (var module in modules)
{
    module.Use(app);
}

app.UseRouting();

app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolOrganizer"); });


app.MapGet("/", () => "Hello in SchoolOrganizer!");

app.Run();

