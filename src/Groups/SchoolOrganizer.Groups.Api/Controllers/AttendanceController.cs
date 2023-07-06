using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganizer.Groups.Core.DTO;
using SchoolOrganizer.Groups.Core.Services;

namespace SchoolOrganizer.Groups.Api.Controllers;
[ApiController]
[Route(GroupsModule.BasePath)]
[Tags(GroupsModule.BasePath)]
public class AttendanceController: ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateAttendanceDto createAttendance)
    {
        await _attendanceService.Create(createAttendance, new CancellationToken());
        return Ok();
    }
}