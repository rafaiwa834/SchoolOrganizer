using SchoolOrganizer.Groups.Core.DTO;

namespace SchoolOrganizer.Groups.Core.Services;

public interface IAttendanceService
{
    public Task Create(CreateAttendanceDto createAttendance, CancellationToken cancellationToken);
}