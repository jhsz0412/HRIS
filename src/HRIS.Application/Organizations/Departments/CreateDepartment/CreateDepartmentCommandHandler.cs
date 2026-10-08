using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities;
using MediatR;

namespace HRIS.Application.Organizations.Departments.CreateDepartment;

public class CreateDepartmentCommandHandler
    : IRequestHandler<CreateDepartmentCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateDepartmentCommandHandler(
        IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(
        CreateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var department = new Department(
            request.CompanyId,
            request.Code,
            request.Name);

        _dbContext.Departments.Add(department);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return department.Id;
    }
}