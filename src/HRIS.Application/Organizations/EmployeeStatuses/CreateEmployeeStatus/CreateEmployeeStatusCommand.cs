using MediatR;

namespace HRIS.Application.Organizations.EmployeeStatuses.CreateEmployeeStatus;

public record CreateEmployeeStatusCommand(
    string Code,
    string Name
) : IRequest<int>;