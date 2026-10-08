using HRIS.Application.Organizations.Departments.CreateDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers.Organizations;

[ApiController]
[Route("api/departments")]
public class DepartmentsController : ControllerBase
{
    private readonly ISender _sender;

    public DepartmentsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateDepartmentCommand command,
        CancellationToken cancellationToken)
    {
        var departmentId = await _sender.Send(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(Create),
            new { id = departmentId },
            new { id = departmentId });
    }
}