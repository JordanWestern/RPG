using RPG.App.Contracts;

namespace RPG.App.Services;

public interface IPlayerService
{
    IAsyncEnumerable<CreatePlayerResponse> GetExistingPlayers(CancellationToken cancellationToken);
}