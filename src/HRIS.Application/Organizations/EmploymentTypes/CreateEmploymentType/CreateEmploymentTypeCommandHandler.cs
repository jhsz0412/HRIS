using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities;
using MediatR;

namespace HRIS.Application.Organizations.EmploymentTypes.CreateEmploymentType;

public class CreateEmploymentTypeCommandHandler
    : IRequestHandler<CreateEmploymentTypeCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateEmploymentTypeCommandHandler(
        IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(
        CreateEmploymentTypeCommand request,
        CancellationToken cancellationToken)
    {
        var employmentType = new EmploymentType(
            request.Code,
            request.Name);

        _dbContext.EmploymentTypes.Add(employmentType);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return employmentType.Id;
    }
}