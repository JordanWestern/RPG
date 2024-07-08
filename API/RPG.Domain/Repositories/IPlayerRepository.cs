using RPG.Domain.Entities;

namespace RPG.Domain.Repositories;

public interface IPlayerRepository
{
    Task SaveNewPlayer(Player player, CancellationToken cancellationToken);

    bool HasExistingPlayers();
    
    IEnumerable<Player> GetExistingPlayers();
}