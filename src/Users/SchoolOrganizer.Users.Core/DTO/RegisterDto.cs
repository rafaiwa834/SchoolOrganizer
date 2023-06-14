using System.ComponentModel.DataAnnotations;
using FluentValidation;
using SchoolOrganizer.Shared.Abstractions.Auth;

namespace SchoolOrganizer.Users.Core.DTO;

public record RegisterDto(string Email, string Password);

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .NotNull().WithMessage("Email is required")
            .EmailAddress().WithMessage("Incorrect email format");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must contain at least 8 signs")
            .Matches(@"[A-Z]+").WithMessage("Use at least one uppercase letter")
            .Matches(@"[a-z]+").WithMessage("Use at least one lowercase letter")
            .Matches(@"[0-9]+").WithMessage("Use at least one number")
            .Matches(@"[\!\?\*\.]+").WithMessage("Use at least one special character");
    }
}