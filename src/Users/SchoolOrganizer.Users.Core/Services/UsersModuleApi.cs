using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Shared.Abstractions.Context;
using SchoolOrganizer.Users.Contracts;
using SchoolOrganizer.Users.Core.DAL;
using SchoolOrganizer.Users.Core.Exceptions;

namespace SchoolOrganizer.Users.Core.Services;

public class UsersModuleApi: IUsersModuleApi
{
    private readonly UsersDbContext _dbContext;

    public UsersModuleApi(UsersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task MakeOwner(Guid userId, Guid companyId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId,cancellationToken) ?? throw new UserNotFoundException(userId.ToString());
        var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name == "Owner", cancellationToken) ?? throw new RoleNotFoundException("Owner");
        user.RoleId = role.Id;
        user.CompanyId = companyId;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}