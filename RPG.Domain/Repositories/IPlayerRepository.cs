using RPG.Domain.Entities;

namespace RPG.Domain.Repositories;

public interface IPlayerRepository
{
    void SaveNewPlayer(Player player);

    bool HasExistingPlayers();
    
    IEnumerable<Player> GetExistingPlayers();
}