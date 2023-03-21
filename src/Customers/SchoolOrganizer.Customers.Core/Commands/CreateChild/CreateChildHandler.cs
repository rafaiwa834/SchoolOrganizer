using SchoolOrganizer.Customers.Domain.Exceptions;
using SchoolOrganizer.Customers.Domain.Repositories;
using SchoolOrganizer.Groups.Contracts;
using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.CreateChild;

public class CreateChildHandler : ICommandHandler<CreateChild>
{
    private readonly IParentsRepository _parentsRepository;
    private readonly IChildrenRepository _childrenRepository;
    private readonly IGroupsModuleApi _groupsModuleApi;

    public CreateChildHandler(IParentsRepository parentsRepository, IChildrenRepository childrenRepository,
        IGroupsModuleApi groupsModuleApi)
    {
        _parentsRepository = parentsRepository;
        _childrenRepository = childrenRepository;
        _groupsModuleApi = groupsModuleApi;
    }

    public async Task HandleAsync(CreateChild command, CancellationToken cancellationToken = default)
    {
        var parent = await _parentsRepository.GetWithChildren(command.ParentId, cancellationToken);
        if (parent is null)
            throw new ParentNotFoundException();
        if (!await _groupsModuleApi.CheckIfGroupExist(command.GroupId, cancellationToken))
            throw new GroupNotFoundException();

        var child = parent.CreateChild(Guid.NewGuid(), command.GroupId, command.FirstName, command.LastName,
            command.BirthDate);
        await _childrenRepository.Create(child, cancellationToken);
    }
}