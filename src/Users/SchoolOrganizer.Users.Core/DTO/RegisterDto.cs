using System.ComponentModel.DataAnnotations;
using SchoolOrganizer.Shared.Abstractions.Auth;

namespace SchoolOrganizer.Users.Core.DTO;

public class RegisterDto
{
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    public string? Role { get; set; }
}