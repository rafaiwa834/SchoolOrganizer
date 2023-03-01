using FluentValidation;

namespace SchoolOrganizer.Groups.Core.DTO;

public class GroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
}


public class GroupDtoValidator : AbstractValidator<GroupDto>
{
    public GroupDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Location)
            .NotEmpty();
    }
} 