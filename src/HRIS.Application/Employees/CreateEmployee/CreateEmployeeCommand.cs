using MediatR;

namespace HRIS.Application.Employees.CreateEmployee;

public record CreateEmployeeCommand(
    string EmployeeNumber,
    string FirstName,
    string LastName,
    string? MiddleName,
    string? Suffix,
    DateOnly? BirthDate,
    string? Gender,
    string? Email,
    string? MobileNumber,
    int CompanyId,
    int DepartmentId,
    int? GroupId,
    int PositionId,
    int EmploymentTypeId,
    int EmployeeStatusId,
    DateOnly DateHired
) : IRequest<int>;