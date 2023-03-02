using FluentValidation;

namespace SchoolOrganizer.Groups.Core.DTO;

public record CreateGroupDto(string Name, string Location, string Description);

public class CreateGroupDtoValidator: AbstractValidator<CreateGroupDto>
{
    public CreateGroupDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(5).WithMessage("Name must contain at least 5 characters");
        
        RuleFor(x => x.Location)
            .NotNull().WithMessage("Location is required")
            .NotEmpty().WithMessage("Location is required")
            .MinimumLength(5).WithMessage("Location must contain at least 5 characters");
    }
}