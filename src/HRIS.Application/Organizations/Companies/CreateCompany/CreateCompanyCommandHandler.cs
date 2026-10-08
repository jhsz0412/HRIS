using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities;
using MediatR;

namespace HRIS.Application.Organizations.Companies.CreateCompany;

public class CreateCompanyCommandHandler
    : IRequestHandler<CreateCompanyCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateCompanyCommandHandler(
        IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(
        CreateCompanyCommand request,
        CancellationToken cancellationToken)
    {
        var company = new Company(
            request.Code,
            request.Name);

        _dbContext.Companies.Add(company);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return company.Id;
    }
}