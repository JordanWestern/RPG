using RPG.Domain.Entities;

namespace RPG.Domain.Events;

public interface IPlayerCreatedEventHandler
{
    public void OnPlayerCreated(Player player);
}