using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities;
using MediatR;

namespace HRIS.Application.Organizations.Groups.CreateGroup;

public class CreateGroupCommandHandler
    : IRequestHandler<CreateGroupCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateGroupCommandHandler(
        IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(
        CreateGroupCommand request,
        CancellationToken cancellationToken)
    {
        var group = new Group(
            request.DepartmentId,
            request.Code,
            request.Name);

        _dbContext.Groups.Add(group);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return group.Id;
    }
}