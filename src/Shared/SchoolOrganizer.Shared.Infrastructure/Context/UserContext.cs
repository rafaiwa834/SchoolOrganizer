using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using SchoolOrganizer.Shared.Abstractions.Context;

namespace SchoolOrganizer.Shared.Infrastructure.Context;

public class UserContext: IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public Guid? UserId => _httpContextAccessor.HttpContext?.User.FindFirstValue(JwtRegisteredClaimNames.Sub).ToGuid();
}

internal static class Extensions
{
    public static Guid? ToGuid(this string? value)
    {
        return Guid.TryParse(value, out var result) ? result : null;
    }
}