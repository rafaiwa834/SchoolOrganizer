using FluentValidation;

namespace SchoolOrganizer.Users.Core.DTO;

public record UpdatePasswordDto(string OldPassword, string NewPassword);

public class UpdatePasswordDtoValidator: AbstractValidator<UpdatePasswordDto>
{
    public UpdatePasswordDtoValidator()
    {
        RuleFor(x=>x.OldPassword)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must contain at least 8 signs");
        
        RuleFor(p => p.NewPassword)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must contain at least 8 signs")
            .Matches(@"[A-Z]+").WithMessage("Use at least one uppercase letter")
            .Matches(@"[a-z]+").WithMessage("Use at least one lowercase letter")
            .Matches(@"[0-9]+").WithMessage("Use at least one number")
            .Matches(@"[\!\?\*\.]+").WithMessage("Use at least one special character");
    }
}