using Microsoft.AspNetCore.SignalR;
using RPG.Domain.Entities;
using RPG.Domain.Events;

namespace RPG.Infrastructure.Events;

public class GameEventService(IHubContext<GameEventHub> hubContext) : IGameEventService
{
    private readonly IHubContext<GameEventHub> _hubContext = hubContext;

    public async Task EmitGameEvent(GameLog log, CancellationToken cancellationToken) =>
        await _hubContext.Clients.All.SendAsync("GameEvent", log, cancellationToken);
}
