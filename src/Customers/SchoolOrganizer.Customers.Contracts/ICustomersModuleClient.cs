namespace SchoolOrganizer.Customers.Contracts;

public interface ICustomersModuleClient
{
    public Task<bool> CheckIfChildrenExists(Guid childrenId, CancellationToken cancellationToken);
    public Task<ParentContractDto> GetParent(Guid parentId, CancellationToken cancellationToken);
}