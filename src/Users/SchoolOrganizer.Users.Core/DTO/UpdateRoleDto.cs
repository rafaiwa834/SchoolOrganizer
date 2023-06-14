using FluentValidation;

namespace SchoolOrganizer.Users.Core.DTO;

public record UpdateRoleDto(Guid Id, int RoleId);

public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
{
    public UpdateRoleDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is required")
            .NotEmpty().WithMessage("Id is required");

        RuleFor(x => x.RoleId)
            .NotNull().WithMessage("Role is required")
            .NotEmpty().WithMessage("Role is required");
    }
}