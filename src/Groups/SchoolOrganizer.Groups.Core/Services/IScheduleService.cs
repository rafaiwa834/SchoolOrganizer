using SchoolOrganizer.Groups.Core.DTO;

namespace SchoolOrganizer.Groups.Core.Services;

public interface IScheduleService
{
    public Task Delete(Guid scheduleId, CancellationToken cancellationToken);
    public Task Create(CreateScheduleDto createScheduleDto, CancellationToken cancellationToken);
}