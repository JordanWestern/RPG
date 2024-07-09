using RPG.App.Contracts;
using RPG.Domain.Entities;
using RPG.Domain.Repositories;

namespace RPG.App.Services;

public class PlayerService(IPlayerRepository repository, IGuidProvider guidProvider) : IPlayerService
{
    public async Task<ExistingPlayer> CreateNewPlayer(NewPlayer newPlayer, CancellationToken cancellationToken)
    {
        var entity = Player.Create(guidProvider, newPlayer.Name);
        await repository.SaveNewPlayer(entity, cancellationToken);
        return new ExistingPlayer(entity.Id, entity.Name);
    }

    public bool HasExistingPlayers() => repository.HasExistingPlayers();
    
    public IEnumerable<ExistingPlayer> GetExistingPlayers()
    {
        var entities = repository.GetExistingPlayers();
        return entities.Select(entity => new ExistingPlayer(entity.Id, entity.Name));
    }
}