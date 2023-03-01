using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace SchoolOrganizer.Users.Core.DTO;

public class LoginDto
{
    public string? Email { get; set; }
    public string Password { get; set; }
}

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(p => p.Password).NotEmpty()
            .MinimumLength(8)
            .NotEmpty();
    }
}
