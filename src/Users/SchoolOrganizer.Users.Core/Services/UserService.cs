using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Companies.Contracts;
using SchoolOrganizer.Shared.Abstractions.Context;
using SchoolOrganizer.Users.Core.DAL;
using SchoolOrganizer.Users.Core.DTO;
using SchoolOrganizer.Users.Core.Exceptions;

namespace SchoolOrganizer.Users.Core.Services;

public class UserService: IUserService
{
    private readonly UsersDbContext _dbContext;
    private readonly IUserContext _userContext;
    private readonly ICompaniesModuleApi _companiesModuleApi;

    public UserService(UsersDbContext dbContext, IUserContext userContext, ICompaniesModuleApi companiesModuleApi)
    {
        _dbContext = dbContext;
        _userContext = userContext;
        _companiesModuleApi = companiesModuleApi;
    }

    public async Task UpdatePassword(UpdatePasswordDto updatePasswordDto, CancellationToken cancellationToken = default)
    {
        Guid? userId = _userContext.UserId ?? throw new ClaimNotFoundException();
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
        if (user is null)
            throw new UserNotFoundException(userId.ToString());
        if (!HashingService.Verify(updatePasswordDto.OldPassword, user.Password))
            throw new InvalidPasswordException();
        user.Password = HashingService.Hash(updatePasswordDto.NewPassword);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateEmail(UpdateEmailDto updateEmailDto, CancellationToken cancellationToken = default)
    {
        Guid? userId = _userContext.UserId  ?? throw new ClaimNotFoundException();
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
        if (user is null)
            throw new UserNotFoundException(userId.ToString());
        var userWithTheSameEmail = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id != userId && x.Email == updateEmailDto.NewEmail, cancellationToken);
        if (userWithTheSameEmail is not null)
            throw new EmailInUseException();
        if (!HashingService.Verify(updateEmailDto.Password, user.Password))
            throw new InvalidPasswordException();
        user.Email = updateEmailDto.NewEmail;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRole(UpdateRoleDto updateRoleDto, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.Include(x=> x.Role).FirstOrDefaultAsync(x => x.Id == updateRoleDto.Id, cancellationToken);
        if (user is null)
            throw new UserNotFoundException(updateRoleDto.Id.ToString());
        var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == updateRoleDto.RoleId);
        if (role is null)
            throw new RoleNotFoundException(updateRoleDto.RoleId.ToString());
        user.RoleId = updateRoleDto.RoleId;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AssignToCompany(Guid userId, Guid comapnyId, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.Include(x=> x.Role).FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
        if (user is null)
            throw new UserNotFoundException(userId.ToString());
        if (await _companiesModuleApi.CheckIfExists(comapnyId, cancellationToken))
            throw new CompanyNotFoundException(comapnyId.ToString());
        user.CompanyId = comapnyId;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
}