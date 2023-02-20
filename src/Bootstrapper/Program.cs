using Bootstrapper;
using Bootstrapper.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchoolOrganizer.Shared.Infrastructure.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();

builder.Host.UseSerilog((configuration, loggerConfiguration) => 
        loggerConfiguration.ReadFrom.Configuration(configuration.Configuration)
    );

var (assemblies, moduleAssemblies, modules) = AppInitializer.Initialize(builder);

foreach (var module in modules)
{
    module.Register(builder.Services, builder.Configuration);
    builder.Services.AddControllers().AddApplicationPart(module.GetType().Assembly);
}

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolOrganizer");
    c.RoutePrefix = string.Empty;
});

app.UseMiddleware<ExceptionMiddleware>();

foreach (var module in modules)
{
    module.Use(app);
}

app.UseEndpoints(endpoints =>
{
    app.MapControllers();
});

if (app.Environment.IsDevelopment())
    await app.Migrate(assemblies);

app.Run();

