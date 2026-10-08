using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities;
using MediatR;

namespace HRIS.Application.Organizations.Positions.CreatePosition;

public class CreatePositionCommandHandler
    : IRequestHandler<CreatePositionCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreatePositionCommandHandler(
        IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(
        CreatePositionCommand request,
        CancellationToken cancellationToken)
    {
        var position = new Position(
            request.Code,
            request.Name);

        _dbContext.Positions.Add(position);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return position.Id;
    }
}