using SchoolOrganizer.Shared.Abstractions.Auth;

namespace SchoolOrganizer.Users.Core.DTO;

public class UserDto
{
    public string Email { get; set; }
    public UserRoles Role { get; set; }
}