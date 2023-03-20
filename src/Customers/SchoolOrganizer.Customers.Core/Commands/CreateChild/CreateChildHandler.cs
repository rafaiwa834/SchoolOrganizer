using System.Runtime.InteropServices;
using SchoolOrganizer.Customers.Domain.Exceptions;
using SchoolOrganizer.Customers.Domain.Repositories;
using SchoolOrganizer.Shared.Abstractions.Commands;
using SchoolOrganizer.Shared.Abstractions.Queries;

namespace SchoolOrganizer.Customers.Core.Commands.CreateChild;

public class CreateChildHandler: ICommandHandler<CreateChild>
{
    private readonly IParentsRepository _parentsRepository;
    private readonly IChildrenRepository _childrenRepository;

    public CreateChildHandler(IParentsRepository parentsRepository, IChildrenRepository childrenRepository)
    {
        _parentsRepository = parentsRepository;
        _childrenRepository = childrenRepository;
    }
    public async Task HandleAsync(CreateChild command, CancellationToken cancellationToken = default)
    {
        var parent = await _parentsRepository.Get(command.ParentId, cancellationToken);
        if (parent is null)
            throw new ParentNotFoundException();
        //check if group exists ( call by contract to group module for this group)
        
        var child = parent.CreateChild(Guid.NewGuid(), command.GroupId, command.FirstName, command.LastName, command.BirthDate);
        await _childrenRepository.Create(child, cancellationToken);
    }
}