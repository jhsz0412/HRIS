using MediatR;

namespace HRIS.Application.Organizations.Companies.CreateCompany;

public record CreateCompanyCommand(
    string Code,
    string Name
) : IRequest<int>;