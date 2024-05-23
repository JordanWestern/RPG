using RPG.App.Contracts;
using RPG.Domain.Entities;
using RPG.Domain.Repositories;

namespace RPG.App.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _repository;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public ExistingPlayer CreateNewPlayer(NewPlayer newPlayer)
    {
        var entity = Player.Create(newPlayer.Name);
        _repository.SaveNewPlayer(entity);
        return new ExistingPlayer(entity.Id, entity.Name);
    }

    public bool HasExistingPlayers() => _repository.HasExistingPlayers();
    
    public IEnumerable<ExistingPlayer> GetExistingPlayers()
    {
        var entities = _repository.GetExistingPlayers();
        return entities.Select(entity => new ExistingPlayer(entity.Id, entity.Name));
    }
}