using FluentValidation;

namespace SchoolOrganizer.Users.Core.DTO;

public record UpdateRoleDto(Guid Id, string Role );

public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
{
    public UpdateRoleDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is required")
            .NotEmpty().WithMessage("Id is required");

        RuleFor(x => x.Role)
            .NotNull().WithMessage("Role is required")
            .NotEmpty().WithMessage("Role is required")
            .Must(x => x is "admin" or "user").WithMessage("Incorrect role");
    }
}