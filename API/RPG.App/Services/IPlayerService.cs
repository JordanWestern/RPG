using RPG.App.Contracts;

namespace RPG.App.Services;

public interface IPlayerService
{
    Task<ExistingPlayer> CreateNewPlayer(NewPlayer newPlayer, CancellationToken cancellationToken);

    public bool HasExistingPlayers();
    
    IEnumerable<ExistingPlayer> GetExistingPlayers();
}