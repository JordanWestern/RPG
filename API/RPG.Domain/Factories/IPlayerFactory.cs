using RPG.Domain.Entities;

namespace RPG.Domain.Factories;

public interface IPlayerFactory
{
    Player Create(string name);
}