using HRIS.Application.Organizations.Companies.CreateCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers.Organizations;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    private readonly ISender _sender;

    public CompaniesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCompanyCommand command,
        CancellationToken cancellationToken)
    {
        var companyId = await _sender.Send(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(Create),
            new { id = companyId },
            new { id = companyId });
    }
}