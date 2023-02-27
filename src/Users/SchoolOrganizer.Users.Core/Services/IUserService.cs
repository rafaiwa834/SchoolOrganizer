using SchoolOrganizer.Users.Core.DTO;

namespace SchoolOrganizer.Users.Core.Services;

public interface IUserService
{
    public Task UpdateRole(UpdateRoleDto updateRoleDto, CancellationToken cancellationToken = default);
    public Task UpdateEmail(UpdateEmailDto updateEmailDto, CancellationToken cancellationToken = default);
    public Task UpdatePassword(UpdatePasswordDto updatePasswordDto, CancellationToken cancellationToken = default);
}