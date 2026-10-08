using HRIS.Application.Organizations.Positions.CreatePosition;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers.Organizations;

[ApiController]
[Route("api/positions")]
public class PositionsController : ControllerBase
{
    private readonly ISender _sender;

    public PositionsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreatePositionCommand command,
        CancellationToken cancellationToken)
    {
        var positionId = await _sender.Send(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(Create),
            new { id = positionId },
            new { id = positionId });
    }
}