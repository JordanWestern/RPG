﻿using Microsoft.AspNetCore.SignalR;
using RPG.Domain.Events;

namespace RPG.Infrastructure.Events;

public class GameEventService(IHubContext<GameEventHub> hubContext) : IGameEventService
{
    private readonly IHubContext<GameEventHub> _hubContext = hubContext;

    public async Task EmitGameEvent(string message, CancellationToken cancellationToken) =>
        await _hubContext.Clients.All.SendAsync("GameEvent", DateTime.Now.ToString("HH:mm:ss"), message, cancellationToken);
}