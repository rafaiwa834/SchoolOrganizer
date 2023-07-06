using SchoolOrganizer.Customers.Contracts;
using SchoolOrganizer.Customers.Domain.Repositories;

namespace SchoolOrganizer.Customers.Infrastructure.Services;

public class CustomersModuleClient: ICustomersModuleClient
{
    private readonly IChildrenRepository _childrenRepository;

    public CustomersModuleClient(IChildrenRepository childrenRepository)
    {
        _childrenRepository = childrenRepository;
    }

    public async Task<bool> CheckIfChildrenExists(Guid childrenId, CancellationToken cancellationToken)
    {
        var children = await _childrenRepository.Get(childrenId, cancellationToken);
        return children is null ? true : false;
    }
}