using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Shared.Abstractions.Auth;
using SchoolOrganizer.Users.Core.DAL;
using SchoolOrganizer.Users.Core.DTO;
using SchoolOrganizer.Users.Core.Entities;
using SchoolOrganizer.Users.Core.Exceptions;

namespace SchoolOrganizer.Users.Core.Services;

public class IdentityService
{
    private UsersDbContext _usersDbContext;
    
    public IdentityService(UsersDbContext usersDbContext)
    {
        _usersDbContext = usersDbContext;
    }

    internal async Task Register(RegisterDto registerDto, CancellationToken cancellationToken = default)
    {
        var user = await _usersDbContext.Users.FirstOrDefaultAsync(x => x.Email == registerDto.Email, cancellationToken);
        if (user is not null)
            throw new EmailInUse();
        var hashedPassword = HashingService.Hash(registerDto.Password);
        user = new User()
        {
            Id = Guid.NewGuid(),
            Password = hashedPassword,
            Email = registerDto.Email,
            Role = registerDto.Role ?? UserRoles.User,
            CreatedAt = DateTime.Now
        };
        await _usersDbContext.Users.AddAsync(user, cancellationToken);
        await _usersDbContext.SaveChangesAsync(cancellationToken);
    }

    internal async Task<JwtToken> Login(LoginDto loginDto)
    {
        
    }
}