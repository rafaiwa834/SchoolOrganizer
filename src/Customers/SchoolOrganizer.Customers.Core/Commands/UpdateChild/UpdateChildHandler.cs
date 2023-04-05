using SchoolOrganizer.Customers.Domain.Repositories;
using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.UpdateChild;

public class UpdateChildHandler: ICommandHandler<UpdateChild>
{
    private readonly IChildrenRepository _childrenRepository;

    public UpdateChildHandler(IChildrenRepository childrenRepository)
    {
        _childrenRepository = childrenRepository;
    }
    public Task HandleAsync(UpdateChild command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}