using RPG.Domain.Entities;

namespace RPG.Domain.Repositories;

public interface IPlayerRepository
{
    void Save(Player player);
    Player Load();
}