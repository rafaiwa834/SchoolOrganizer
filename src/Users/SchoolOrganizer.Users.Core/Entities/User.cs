using System.Runtime;
using SchoolOrganizer.Companies.Contracts;
using SchoolOrganizer.Shared.Abstractions.Auth;

namespace SchoolOrganizer.Users.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }

    public Guid CompanyId { get; set; }
}