using RPG.App.Contracts;

namespace RPG.App.Services;

public interface IPlayerService
{
    ExistingPlayer CreateNewPlayer(NewPlayer newPlayer);

    public bool HasExistingPlayers();
    
    IEnumerable<ExistingPlayer> GetExistingPlayers();
}