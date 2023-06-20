using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Companies.Contracts;
using SchoolOrganizer.Companies.Core.DAL;
using SchoolOrganizer.Companies.Core.Entities;

namespace SchoolOrganizer.Companies.Core.Services;

public class CompaniesModuleApi: ICompaniesModuleApi
{
    private readonly DbSet<Company> companiesDbContext;
    
    public CompaniesModuleApi(CompaniesDbContext companiesDbContext)
    {
        this.companiesDbContext = companiesDbContext.Companies;
    }

    public async Task<Company> Get(Guid companyId, CancellationToken cancellationToken = default)
    {
        return await companiesDbContext.FirstOrDefaultAsync(x => x.Id == companyId, cancellationToken);
    }

    public async Task<bool> CheckIfExists(Guid companyId, CancellationToken cancellationToken = default)
    {
        return await companiesDbContext.FirstOrDefaultAsync(x => x.Id == companyId, cancellationToken) is not null;
    }
}