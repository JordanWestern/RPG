using MediatR;
using RPG.Domain.Factories;
using RPG.Domain.Repositories;

namespace RPG.Domain.Events;

public class PlayerCreatedEventHandler(IGameLogFactory gameLogFactory, IGameLogRepository gameLogRepository, IGameEventService gameEventService) : INotificationHandler<PlayerCreatedEvent>
{
    public async Task Handle(PlayerCreatedEvent @event, CancellationToken cancellationToken)
    {
        var log = gameLogFactory.Create(@event.Player.Id, $"Player was created. Id: {@event.Player.Id} Name: {@event.Player.Name}");
        await gameLogRepository.CreateLog(log, cancellationToken);
        await gameEventService.EmitGameEvent(log, cancellationToken);
    }
}
