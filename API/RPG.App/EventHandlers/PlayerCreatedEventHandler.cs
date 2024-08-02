using MediatR;
using RPG.App.Dialogs;
using RPG.Domain.Entities;
using RPG.Domain.Events;
using RPG.Domain.Repositories;

namespace RPG.App.EventHandlers;

public class PlayerCreatedEventHandler(IGameLogRepository gameLogRepository) : INotificationHandler<PlayerCreatedEvent>
{
    public async Task Handle(PlayerCreatedEvent @event, CancellationToken cancellationToken)
    {
        var log = GameLog.Create(@event.Player.Id, Dialog.OpeningDialog(@event.Player.Name));
        await gameLogRepository.CreateLog(log, cancellationToken);
    }
}