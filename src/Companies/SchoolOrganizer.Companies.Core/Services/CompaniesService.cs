using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Companies.Core.DAL;
using SchoolOrganizer.Companies.Core.DTO;
using SchoolOrganizer.Companies.Core.Entities;
using SchoolOrganizer.Companies.Core.Exceptions;
using SchoolOrganizer.Shared.Abstractions.Context;
using SchoolOrganizer.Users.Contracts;

namespace SchoolOrganizer.Companies.Core.Services;

public class CompaniesService
{
    private readonly DbSet<Company> companiesDbContext;
    private readonly CompaniesDbContext dbContext;
    private readonly IUserContext userContext;
    private readonly IUsersModuleApi usersModuleApi;

    public CompaniesService(CompaniesDbContext dbContext, IUserContext userContext, IUsersModuleApi usersModuleApi)
    {
        companiesDbContext = dbContext.Companies;
        this.dbContext = dbContext;
        this.userContext = userContext;
        this.usersModuleApi = usersModuleApi;
    }

    public async void Create(CreateCompany createCompany, CancellationToken cancellationToken)
    {
        var userId = userContext.UserId ?? throw new UserIdNotFound();
        var company = new Company()
        {
            Id = Guid.NewGuid(),
            Name = createCompany.Name,
            Description = createCompany.Description
        };
        await usersModuleApi.MakeOwner(userId, company.Id, cancellationToken);
        await companiesDbContext.AddAsync(company, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
}