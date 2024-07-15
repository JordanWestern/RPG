using RPG.Domain.Entities;

namespace RPG.Domain.Factories;

public interface IGameLogFactory
{
    public GameLog Create(Guid playerId, string message);
}