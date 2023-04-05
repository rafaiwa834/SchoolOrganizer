using SchoolOrganizer.Customers.Core.DTO;
using SchoolOrganizer.Customers.Domain.Exceptions;
using SchoolOrganizer.Customers.Domain.Repositories;
using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.DeleteParent;

public class DeleteParentHandler: ICommandHandler<DeleteParent>
{
    private readonly IParentsRepository _parentsRepository;

    public DeleteParentHandler(IParentsRepository parentsRepository)
    {
        _parentsRepository = parentsRepository;
    }
    
    public async Task HandleAsync(DeleteParent command, CancellationToken cancellationToken)
    {
        var parent = await _parentsRepository.GetWithChildren(command.Id, cancellationToken)
                     ?? throw new ParentNotFoundException();
        await _parentsRepository.Remove(parent, cancellationToken);
    }
}