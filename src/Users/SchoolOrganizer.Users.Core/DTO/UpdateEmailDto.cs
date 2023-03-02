using FluentValidation;

namespace SchoolOrganizer.Users.Core.DTO;

public record UpdateEmailDto(string Password, string NewEmail);

public class UpdateEmailDtoValidator: AbstractValidator<UpdateEmailDto>
{
    public UpdateEmailDtoValidator()
    {
        RuleFor(x=>x.NewEmail)
            .NotEmpty().WithMessage("Email is required")
            .NotNull().WithMessage("Email is required")
            .EmailAddress().WithMessage("Incorrect email format");
        
        RuleFor(x=> x.Password)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must contain at least 8 signs");
    }
}