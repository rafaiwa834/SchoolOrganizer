using SchoolOrganizer.Groups.Core.DTO;

namespace SchoolOrganizer.Groups.Core.Services;

public interface IGroupsService
{
    public Task<IEnumerable<GroupDto>> GetAll(CancellationToken cancellationToken = default);
    public Task<GroupDto> Get(Guid id, CancellationToken cancellationToken = default);
    public Task<Guid> Create(CreateGroupDto createGroupDto, CancellationToken cancellationToken = default);
    public Task Update(Guid id, UpdateGroupDto updateGroupDto, CancellationToken cancellationToken = default);
    public Task Delete(Guid id, CancellationToken cancellationToken = default);
}