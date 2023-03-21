using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganizer.Customers.Core.Commands.CreateParent;
using SchoolOrganizer.Customers.Core.DTO;
using SchoolOrganizer.Customers.Core.Queries.GetAllParents;
using SchoolOrganizer.Customers.Core.Queries.GetParent;
using SchoolOrganizer.Shared.Abstractions.Commands;
using SchoolOrganizer.Shared.Abstractions.Queries;

namespace SchoolOrganizer.Api.Controllers;

[ApiController]
[Tags(CustomersModule.BasePath)]
[Route(CustomersModule.BasePath + "/[controller]")]
public class ParentController: ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ParentController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateParent createParent)
    {
        await _commandDispatcher.SendAsync(createParent, new CancellationToken());
        return NoContent();
    }

    [HttpGet()]
    public async Task<IList<ParentDto>> GetAll()
    {
        return await _queryDispatcher.QueryAsync(new GetAllParents(), new CancellationToken());
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ParentDto> Get(Guid id)
    {
        return await _queryDispatcher.QueryAsync(new GetParent(Id: id), new CancellationToken());
    }

}