using System.ComponentModel.DataAnnotations;

namespace SchoolOrganizer.Users.Core.DTO;

public class LoginDto
{
    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    [Required]
    public string Password { get; set; }
}