using RPG.App.Contracts;

namespace RPG.App.Services;

public interface IPlayerService
{
    void CreateNewPlayer(NewPlayer newPlayer);

    public bool HasExistingPlayers();
    
    IEnumerable<ExistingPlayer> GetExistingPlayers();
}