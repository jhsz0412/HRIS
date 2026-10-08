using MediatR;

namespace HRIS.Application.Organizations.Departments.CreateDepartment;

public record CreateDepartmentCommand(
    int CompanyId,
    string Code,
    string Name
) : IRequest<int>;