using SchoolOrganizer.Companies.Core.DTO;

namespace SchoolOrganizer.Companies.Core.Services;

public interface ICompanyService
{
    public Task Create(CreateCompany createCompany, CancellationToken cancellationToken);

    public Task<IEnumerable<CompanyDto>> GetAll(CancellationToken cancellationToken);

}