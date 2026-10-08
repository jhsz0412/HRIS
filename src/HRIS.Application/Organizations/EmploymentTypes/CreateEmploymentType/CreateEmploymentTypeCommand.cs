using MediatR;

namespace HRIS.Application.Organizations.EmploymentTypes.CreateEmploymentType;

public record CreateEmploymentTypeCommand(
    string Code,
    string Name
) : IRequest<int>;