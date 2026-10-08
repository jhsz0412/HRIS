using HRIS.Application.Organizations.EmploymentTypes.CreateEmploymentType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers.Organizations;

[ApiController]
[Route("api/employment-types")]
public class EmploymentTypesController : ControllerBase
{
    private readonly ISender _sender;

    public EmploymentTypesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateEmploymentTypeCommand command,
        CancellationToken cancellationToken)
    {
        var employmentTypeId = await _sender.Send(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(Create),
            new { id = employmentTypeId },
            new { id = employmentTypeId });
    }
}