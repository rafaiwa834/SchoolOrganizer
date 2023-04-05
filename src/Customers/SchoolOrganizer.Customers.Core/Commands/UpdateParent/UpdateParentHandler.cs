using SchoolOrganizer.Customers.Domain.Exceptions;
using SchoolOrganizer.Customers.Domain.Repositories;
using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.UpdateParent;

public class UpdateParentHandler: ICommandHandler<UpdateParent>
{
    private readonly IParentsRepository _parentsRepository;

    public UpdateParentHandler(IParentsRepository parentsRepository)
    {
        _parentsRepository = parentsRepository;
    }
    public async Task HandleAsync(UpdateParent command, CancellationToken cancellationToken)
    {
        var parent = await _parentsRepository.Get(command.Id, cancellationToken)
            ?? throw new ParentNotFoundException();
        
        parent.Update(command.LastName, command.Email, command.PhoneNumber, command.Street,
            command.BuildNumber, command.City, command.PostalCode);
        await _parentsRepository.Update(parent, cancellationToken);
    }
}