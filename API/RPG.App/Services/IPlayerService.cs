using RPG.App.Contracts;

namespace RPG.App.Services;

public interface IPlayerService
{
    Task<ExistingPlayer> CreateNewPlayer(NewPlayer newPlayer, CancellationToken cancellationToken);

    IAsyncEnumerable<ExistingPlayer> GetExistingPlayers(CancellationToken cancellationToken);
}