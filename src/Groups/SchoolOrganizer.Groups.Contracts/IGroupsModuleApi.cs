namespace SchoolOrganizer.Groups.Contracts;

public interface IGroupsModuleApi
{
    public Task<bool> CheckIfGroupExist(Guid id, CancellationToken cancellationToken);
}