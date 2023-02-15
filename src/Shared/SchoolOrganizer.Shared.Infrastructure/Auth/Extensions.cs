using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Auth;
using SchoolOrganizer.Shared.Infrastructure.Settings;

namespace SchoolOrganizer.Shared.Infrastructure.Auth;

public static class Extensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtTokenSettings = configuration.GetOptions<JwtTokenSettings>();
        services.AddScoped<JwtTokenSettings>();
        services.AddScoped<ITokenManager, TokenManager>();
        return services;
    }
}