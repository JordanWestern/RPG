using Microsoft.AspNetCore.SignalR;

namespace RPG.Api.Events;

public class GameEventHub : Hub
{
    public async Task SendEvent(string time, string logMessage, CancellationToken cancellationToken) =>
        await Clients.All.SendAsync("ReceiveLog", time, logMessage, cancellationToken);
}
