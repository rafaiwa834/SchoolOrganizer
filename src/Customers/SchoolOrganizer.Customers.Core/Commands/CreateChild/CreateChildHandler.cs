using System.Runtime.InteropServices;
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
    public async Task HandleAsync(CreateChild command, CancellationToken cancellationToken)
    {
        await Task.Delay(2);
    }
}