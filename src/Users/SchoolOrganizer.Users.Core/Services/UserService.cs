using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Shared.Abstractions.Context;
using SchoolOrganizer.Users.Core.DAL;
using SchoolOrganizer.Users.Core.DTO;
using SchoolOrganizer.Users.Core.Exceptions;

namespace SchoolOrganizer.Users.Core.Services;

internal class UserService
{
    private readonly UsersDbContext _dbContext;
    private readonly IUserContext _userContext;

    internal UserService(UsersDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
    }

    internal async Task UpdatePassword(UpdatePasswordDto updatePasswordDto, CancellationToken cancellationToken = default)
    {

        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == _userContext.UserId, cancellationToken);
        if (user is null)
            throw new UserNotFound(_userContext.UserId.ToString());
        if (!HashingService.Verify(updatePasswordDto.oldPassword, user.Password))
            throw new InvalidPassword();
        user.Password = HashingService.Hash(updatePasswordDto.newPassword);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    internal void UpdateEmail(UpdateEmailDto updateEmailDto)
    {
        
    }
    
    internal void UpdateRole()
    {}
    
}