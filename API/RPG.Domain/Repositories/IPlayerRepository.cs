using RPG.Domain.Entities;

namespace RPG.Domain.Repositories;

public interface IPlayerRepository
{
    Task SaveNewPlayer(Player player, CancellationToken cancellationToken);
    
    IAsyncEnumerable<Player> GetExistingPlayers(CancellationToken cancellationToken);
}