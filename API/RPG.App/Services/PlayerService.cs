using RPG.App.Contracts;
using RPG.Domain.Repositories;

namespace RPG.App.Services;

public class PlayerService(IPlayerRepository repository) : IPlayerService
{  
    public IAsyncEnumerable<CreatePlayerResponse> GetExistingPlayers(CancellationToken cancellationToken) =>
        repository.GetExistingPlayers(cancellationToken)
        .Select(entity => new CreatePlayerResponse(entity.Id, entity.Name));
 
}