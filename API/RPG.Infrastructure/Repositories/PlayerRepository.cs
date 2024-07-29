using MediatR;
using RPG.Domain.Entities;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;

namespace RPG.Infrastructure.Repositories;

public class PlayerRepository(ApplicationDbContext context, IMediator mediator) : IPlayerRepository
{
    public async Task SaveNewPlayer(Player player, CancellationToken cancellationToken)
    {
        context.Players.Add(player);
        await context.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in player.DomainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
    }

    public IAsyncEnumerable<Player> GetExistingPlayers(CancellationToken cancellationToken) =>
        context.Players.AsAsyncEnumerable();
}