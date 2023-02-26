using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Context;
using SchoolOrganizer.Shared.Abstractions.Module;
using SchoolOrganizer.Shared.Abstractions.Time;
using SchoolOrganizer.Shared.Infrastructure.Auth;
using SchoolOrganizer.Shared.Infrastructure.Context;
using SchoolOrganizer.Shared.Infrastructure.Time;

namespace SchoolOrganizer.Shared.Infrastructure;

public class InfrastructureModel : IModule
{
    public string Name { get; } = "Shared Infrastructure";

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuth(configuration);
        services.AddScoped<IClock, Clock>();
        services.AddSingleton<IUserContext, UserContext>();
    }

    public void Use(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}