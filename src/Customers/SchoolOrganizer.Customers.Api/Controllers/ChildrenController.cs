using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganizer.Customers.Core.Commands;
using SchoolOrganizer.Customers.Core.Commands.CreateChild;
using SchoolOrganizer.Shared.Abstractions.Commands;
using SchoolOrganizer.Shared.Abstractions.Queries;

namespace SchoolOrganizer.Api.Controllers;
[ApiController]
[Tags(CustomersModule.BasePath)]
[Route(CustomersModule.BasePath)]
public class ChildrenController: ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public ChildrenController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<ActionResult> CreatedResult([FromBody] CreateChild createChild)
    {
        await _commandDispatcher.SendAsync(createChild, new CancellationToken());
        return NoContent();
    }
    
}