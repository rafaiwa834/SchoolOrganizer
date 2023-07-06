namespace SchoolOrganizer.Customers.Contracts;

public interface ICustomersModuleClient
{
    public Task<bool> CheckIfChildrenExists(Guid childrenId, CancellationToken cancellationToken);
}