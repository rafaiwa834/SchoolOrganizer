using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganizer.Companies.Core.DTO;
using SchoolOrganizer.Companies.Core.Services;

namespace SchoolOrganizer.Companies.Api.Controllers;
[ApiController]
[Route(CompaniesModule.BasePath)]
[Tags(CompaniesModule.BasePath)]
[Authorize]
public class CompaniesController: ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCompany createCompany)
    {
        await _companyService.Create(createCompany, new CancellationToken());
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll()
    {
        var results = await _companyService.GetAll(new CancellationToken());
        return Ok(results);
    }

}