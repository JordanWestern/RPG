using RPG.App.Contracts;
using RPG.Domain.Entities;
using RPG.Domain.Repositories;

namespace RPG.App.Services;

public class PlayerService(IPlayerRepository repository) : IPlayerService
{
    public async Task<ExistingPlayer> CreateNewPlayer(NewPlayer newPlayer, CancellationToken cancellationToken)
    {
        var entity = Player.Create(newPlayer.Name);
        await repository.SaveNewPlayer(entity, cancellationToken);
        return new ExistingPlayer(entity.Id, entity.Name);
    }
    
    public IAsyncEnumerable<ExistingPlayer> GetExistingPlayers(CancellationToken cancellationToken) =>
        repository.GetExistingPlayers(cancellationToken)
        .Select(entity => new ExistingPlayer(entity.Id, entity.Name));
 
}