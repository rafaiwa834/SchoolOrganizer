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

    public async Task<IEnumerable<ParentContractDto>> GetParents(List<Guid> parentIds, CancellationToken cancellationToken)
    {
        var parents = await _parentsRepository.GetMultiple(parentIds, cancellationToken);
        return parents.Select(p =>
            new ParentContractDto(p.Id, p.FirstName, p.LastName, p.Email, p.PhoneNumber));
    }
}