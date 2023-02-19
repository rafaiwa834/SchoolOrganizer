using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolOrganizer.Shared.Abstractions.Auth;
using SchoolOrganizer.Shared.Infrastructure.Settings;

namespace SchoolOrganizer.Shared.Infrastructure.Auth;

public static class Extensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtTokenSettings = configuration.GetOptions<JwtTokenSettings>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidAudience = jwtTokenSettings.Audience,
                        ValidateAudience = jwtTokenSettings.ValidateAudience,
                        ValidIssuer = jwtTokenSettings.Issuer,
                        ValidateIssuer = jwtTokenSettings.ValidateIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenSettings.Key)), 
                        ValidateIssuerSigningKey = jwtTokenSettings.ValidateKey,
                        ValidateLifetime = jwtTokenSettings.ValidateLifetime
                    };
                });
        services.AddAuthorization();
        services.AddScoped<ITokenManager, TokenManager>();
        services.AddSingleton(jwtTokenSettings);
        return services;
    }
}