using RPG.Domain.Entities;
using RPG.Domain.Repositories;

namespace RPG.Domain.Events;

public class PlayerCreatedEventHandler : IPlayerCreatedEventHandler
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerCreatedEventHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public void OnPlayerCreated(Player player) => _playerRepository.Save(player);
}