using MediatR;
using Microsoft.AspNetCore.SignalR;
using RPG.Domain.Events;
using RPG.Infrastructure.Events;

namespace RPG.App.EventHandlers;

internal class GameLogCreatedEventHandler(IHubContext<GameEventHub> hubContext) : INotificationHandler<GameLogCreatedEvent>
{
    public async Task Handle(GameLogCreatedEvent notification, CancellationToken cancellationToken) => 
        await hubContext.Clients.All.SendAsync("GameLog", notification.GameLog, cancellationToken);
}
