using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities;
using MediatR;

namespace HRIS.Application.Employees.CreateEmployee;

public class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateEmployeeCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = new Employee(
            request.EmployeeNumber,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Suffix,
            request.BirthDate,
            request.Gender,
            request.Email,
            request.MobileNumber,
            request.CompanyId,
            request.DepartmentId,
            request.GroupId,
            request.PositionId,
            request.EmploymentTypeId,
            request.EmployeeStatusId,
            request.DateHired
        );

        _dbContext.Employees.Add(employee);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}