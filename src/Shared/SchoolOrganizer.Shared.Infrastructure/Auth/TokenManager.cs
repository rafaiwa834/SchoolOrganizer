using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SchoolOrganizer.Shared.Abstractions.Auth;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SchoolOrganizer.Shared.Infrastructure.Auth;

public class TokenManager: ITokenManager
{
    private readonly JwtTokenSettings _jwtTokenSettings;
    public TokenManager(JwtTokenSettings jwtTokenSettings)
    {
        _jwtTokenSettings = jwtTokenSettings;
    }
    
    public async Task<JwtToken> CreateToken(string userId, string userRole, string userEmail)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userEmail),
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(ClaimTypes.Role, userRole)
        };

        var expiresTime = DateTime.Now.AddMinutes(_jwtTokenSettings.DurationInMinutes);
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

        return new JwtToken()
        {
            UserId = userId,
            Token = token
        };
    }
}