using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Shared.Abstractions.Context;
using SchoolOrganizer.Users.Core.DAL;
using SchoolOrganizer.Users.Core.DTO;
using SchoolOrganizer.Users.Core.Exceptions;

namespace SchoolOrganizer.Users.Core.Services;

public class UserService: IUserService
{
    private readonly UsersDbContext _dbContext;
    private readonly IUserContext _userContext;

    public UserService(UsersDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
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
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == updateRoleDto.Id, cancellationToken);
        if (user is null)
            throw new UserNotFoundException(updateRoleDto.Id.ToString());
        user.Role = updateRoleDto.Role;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
}