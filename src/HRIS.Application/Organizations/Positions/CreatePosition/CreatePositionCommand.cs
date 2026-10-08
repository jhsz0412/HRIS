using MediatR;

namespace HRIS.Application.Organizations.Positions.CreatePosition;

public record CreatePositionCommand(
    string Code,
    string Name
) : IRequest<int>;