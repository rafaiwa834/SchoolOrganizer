namespace SchoolOrganizer.Users.Contracts;

public interface IUsersModuleApi
{
    public Task MakeOwner(Guid userId, Guid companyId, CancellationToken cancellationToken);
}