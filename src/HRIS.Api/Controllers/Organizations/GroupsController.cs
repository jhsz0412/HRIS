using HRIS.Application.Organizations.Groups.CreateGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers.Organizations;

[ApiController]
[Route("api/groups")]
public class GroupsController : ControllerBase
{
    private readonly ISender _sender;

    public GroupsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateGroupCommand command,
        CancellationToken cancellationToken)
    {
        var groupId = await _sender.Send(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(Create),
            new { id = groupId },
            new { id = groupId });
    }
}