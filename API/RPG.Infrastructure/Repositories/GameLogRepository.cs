using MediatR;
using Microsoft.EntityFrameworkCore;
using RPG.Domain.Entities;
using RPG.Domain.Repositories;
using RPG.Domain.ValueObjects;
using RPG.Infrastructure.DbContexts;

namespace RPG.Infrastructure.Repositories;

public class GameLogRepository(ApplicationDbContext context, IMediator mediator) : IGameLogRepository
{
    public async Task CreateLog(GameLog gameLog, CancellationToken cancellationToken)
    {
        context.GameLogs.Add(gameLog);
        await context.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in gameLog.DomainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
    }

    public GameLogs GetLogs(Guid playerId, CancellationToken cancellationToken) =>
        new(context.GameLogs
            .Where(log => log.PlayerId == playerId)
            .AsAsyncEnumerable());
}
