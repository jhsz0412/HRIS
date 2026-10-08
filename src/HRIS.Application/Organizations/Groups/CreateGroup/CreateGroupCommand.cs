using MediatR;

namespace HRIS.Application.Organizations.Groups.CreateGroup;

public record CreateGroupCommand(
    int DepartmentId,
    string Code,
    string Name
) : IRequest<int>;