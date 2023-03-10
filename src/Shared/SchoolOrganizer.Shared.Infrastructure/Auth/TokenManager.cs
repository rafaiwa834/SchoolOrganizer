using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolOrganizer.Shared.Abstractions.Auth;
using SchoolOrganizer.Shared.Abstractions.Time;
using SchoolOrganizer.Shared.Infrastructure.Settings;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SchoolOrganizer.Shared.Infrastructure.Auth;

public class TokenManager: ITokenManager
{
    private readonly JwtTokenSettings _jwtTokenSettings;
    private readonly IClock _clock;

    public TokenManager(JwtTokenSettings jwtTokenSettings, IClock clock)
    {
        _jwtTokenSettings = jwtTokenSettings;
        _clock = clock;
    }
    
    public string CreateToken(string userId, string userRole, string userEmail)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userEmail),
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(ClaimTypes.Role, userRole)
        };
        var expiresTime = _clock.GetDateTimeNow().AddMinutes(_jwtTokenSettings.DurationInMinutes);
        var key = Encoding.ASCII.GetBytes(_jwtTokenSettings.Key);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);
        
        var jwt = new JwtSecurityToken(
            issuer: _jwtTokenSettings.Issuer,
            audience: _jwtTokenSettings.Audience,
            claims: claims,
            expires: expiresTime,
            signingCredentials: signingCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return token;
    }
    
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }

    public ClaimsPrincipal GetPrincipal(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = _jwtTokenSettings.ValidateAudience,
            ValidAudience = _jwtTokenSettings.Audience,
            ValidateIssuer = _jwtTokenSettings.ValidateIssuer,
            ValidIssuer = _jwtTokenSettings.Issuer,
            ValidateIssuerSigningKey = _jwtTokenSettings.ValidateKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtTokenSettings.Key)),
            ValidateLifetime = false
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        tokenHandler.InboundClaimTypeMap.Clear();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Refresh token is invalid");
        
        return principal;
    }    
    
}