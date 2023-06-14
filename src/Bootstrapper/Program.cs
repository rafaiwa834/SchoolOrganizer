using Bootstrapper;
using Bootstrapper.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchoolOrganizer.Shared.Infrastructure;
using SchoolOrganizer.Shared.Infrastructure.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();

builder.Host.UseSerilog((configuration, loggerConfiguration) => 
        loggerConfiguration.ReadFrom.Configuration(configuration.Configuration)
    );

var (assemblies, moduleAssemblies, modules) = AppInitializer.Initialize(builder);

builder.Services.RegisterInfrastructure(builder.Configuration, assemblies);
foreach (var module in modules)
{
    module.Register(builder.Services, builder.Configuration);
    builder.Services.AddControllers().AddApplicationPart(module.GetType().Assembly);
}

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(moduleAssemblies);

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo(){Title = "SchoolOrganizer", Version = "v1"});
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolOrganizer");
    c.RoutePrefix = string.Empty;
});

app.UseMiddleware<ExceptionMiddleware>();

app.UseInfrastructure();
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

