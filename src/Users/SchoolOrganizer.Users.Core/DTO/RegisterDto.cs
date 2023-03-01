using System.ComponentModel.DataAnnotations;
using FluentValidation;
using SchoolOrganizer.Shared.Abstractions.Auth;

namespace SchoolOrganizer.Users.Core.DTO;

public class RegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Role { get; set; }
}

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(p => p.Password).NotEmpty()
            .MinimumLength(8)
            .Matches(@"[A-Z]+")
            .Matches(@"[a-z]+")
            .Matches(@"[0-9]+")
            .Matches(@"[\!\?\*\.]+");
    }
}