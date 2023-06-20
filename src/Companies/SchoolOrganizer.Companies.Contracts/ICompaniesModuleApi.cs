namespace SchoolOrganizer.Companies.Contracts;

public interface ICompaniesModuleApi
{
    public Task<bool> CheckIfExists(Guid companyId, CancellationToken cancellationToken = default);
}