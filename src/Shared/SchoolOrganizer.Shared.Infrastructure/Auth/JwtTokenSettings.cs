using SchoolOrganizer.Shared.Abstractions.Settings;
using SchoolOrganizer.Shared.Infrastructure.Settings;

namespace SchoolOrganizer.Shared.Abstractions.Auth;

public class JwtTokenSettings: ISettings
{
    public string Key { get; set; }
    public bool ValidateKey { get; set; }
    public string Issuer { get; set; }
    public bool ValidateIssuer { get; set; }
    public string Audience { get; set; }
    public bool ValidateAudience { get; set; }
    public double DurationInMinutes { get; set; }
    public bool ValidateLifetime { get; set; }
    public static string SectionName => "Auth";
}