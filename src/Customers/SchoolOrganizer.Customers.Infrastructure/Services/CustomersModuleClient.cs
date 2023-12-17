using SchoolOrganizer.Customers.Contracts;
using SchoolOrganizer.Customers.Domain.Entities;
using SchoolOrganizer.Customers.Domain.Repositories;

namespace SchoolOrganizer.Customers.Infrastructure.Services;

public class CustomersModuleClient: ICustomersModuleClient
{
    private readonly IChildrenRepository _childrenRepository;
    private readonly IParentsRepository _parentsRepository;

    public CustomersModuleClient(IChildrenRepository childrenRepository, IParentsRepository parentsRepository)
    {
        _childrenRepository = childrenRepository;
        _parentsRepository = parentsRepository;
    }

    public async Task<bool> CheckIfChildrenExists(Guid childrenId, CancellationToken cancellationToken)
    {
        var children = await _childrenRepository.Get(childrenId, cancellationToken);
        return children is not null;
    }

    public async Task<ParentContractDto> GetParent(Guid parentId, CancellationToken cancellationToken)
    {
        var parent = await _parentsRepository.Get(parentId, cancellationToken);
        return new ParentContractDto(parent.Id, parent.FirstName, parent.LastName, parent.Email, parent.PhoneNumber);
    }
}