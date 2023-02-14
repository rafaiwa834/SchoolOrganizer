using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Auth;

namespace SchoolOrganizer.Shared.Infrastructure.Auth;

public static class Extensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddScoped<ITokenManager, TokenManager>();
        return services;
    }
}