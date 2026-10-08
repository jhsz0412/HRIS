using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities;
using MediatR;

namespace HRIS.Application.Organizations.EmployeeStatuses.CreateEmployeeStatus;

public class CreateEmployeeStatusCommandHandler
    : IRequestHandler<CreateEmployeeStatusCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateEmployeeStatusCommandHandler(
        IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(
        CreateEmployeeStatusCommand request,
        CancellationToken cancellationToken)
    {
        var employeeStatus = new EmployeeStatus(
            request.Code,
            request.Name);

        _dbContext.EmployeeStatuses.Add(employeeStatus);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return employeeStatus.Id;
    }
}