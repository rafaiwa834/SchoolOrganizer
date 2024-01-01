namespace SchoolOrganizer.Customers.Contracts;

public interface ICustomersModuleClient
{
    public Task<bool> CheckIfChildrenExists(Guid childrenId, CancellationToken cancellationToken);
    public Task<IEnumerable<ParentContractDto>> GetParents(List<Guid> parentIds, CancellationToken cancellationToken);
}