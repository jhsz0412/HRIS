using HRIS.Application.Employees.CreateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers.Employees;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly ISender _sender;

    public EmployeesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateEmployeeCommand command,
        CancellationToken cancellationToken)
    {
        var employeeId = await _sender.Send(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(Create),
            new { id = employeeId },
            new { id = employeeId });
    }
}