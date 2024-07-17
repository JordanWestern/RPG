using Microsoft.AspNetCore.SignalR;
using RPG.Domain.Entities;
using RPG.Infrastructure.Events;

namespace RPG.App.Services;

public class GameEventService(IHubContext<GameEventHub> hubContext) : IGameEventService
{
    public async Task EmitGameEvent(GameLog log, CancellationToken cancellationToken) =>
        await hubContext.Clients.All.SendAsync("GameEvent", log, cancellationToken);
}
