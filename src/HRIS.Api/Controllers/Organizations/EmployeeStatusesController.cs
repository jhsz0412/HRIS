using HRIS.Application.Organizations.EmployeeStatuses.CreateEmployeeStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers.Organizations;

[ApiController]
[Route("api/employee-statuses")]
public class EmployeeStatusesController : ControllerBase
{
    private readonly ISender _sender;

    public EmployeeStatusesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateEmployeeStatusCommand command,
        CancellationToken cancellationToken)
    {
        var employeeStatusId = await _sender.Send(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(Create),
            new { id = employeeStatusId },
            new { id = employeeStatusId });
    }
}