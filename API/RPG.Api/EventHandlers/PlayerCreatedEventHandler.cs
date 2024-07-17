using MediatR;
using RPG.App.Services;
using RPG.Domain.Entities;
using RPG.Domain.Events;
using RPG.Domain.Repositories;

namespace RPG.Api.EventHandlers;

public class PlayerCreatedEventHandler(IGameLogRepository gameLogRepository, IGameEventService gameEventService) : INotificationHandler<PlayerCreatedEvent>
{
    public async Task Handle(PlayerCreatedEvent @event, CancellationToken cancellationToken)
    {
        var log = GameLog.Create(@event.Player.Id, $"Player was created. Id: {@event.Player.Id} Name: {@event.Player.Name}");
        await gameLogRepository.CreateLog(log, cancellationToken);
        await gameEventService.EmitGameEvent(log, cancellationToken);
    }
}
