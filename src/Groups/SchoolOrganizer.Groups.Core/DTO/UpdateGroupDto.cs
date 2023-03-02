using FluentValidation;

namespace SchoolOrganizer.Groups.Core.DTO;

public class UpdateGroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Location { get; set; } 
    public string? Description { get; set; }
}

public class UpdateGroupDtoValidator: AbstractValidator<UpdateGroupDto>
{
    public UpdateGroupDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is required")
            .NotEmpty().WithMessage("Id is required");

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