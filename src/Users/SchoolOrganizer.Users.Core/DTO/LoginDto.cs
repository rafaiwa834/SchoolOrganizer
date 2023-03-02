using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace SchoolOrganizer.Users.Core.DTO;

public record LoginDto(string Email, string Password);

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .NotNull().WithMessage("Email is required")
            .EmailAddress().WithMessage("Incorrect email format");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must contain at least 8 signs");
    }
}
