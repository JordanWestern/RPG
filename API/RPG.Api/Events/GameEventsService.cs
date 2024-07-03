using Microsoft.AspNetCore.SignalR;

namespace RPG.Api.Events
{
    public class GameEventsService
    {
        private readonly IHubContext<GameEventHub> _hubContext;

        public GameEventsService(IHubContext<GameEventHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendEvent(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveLog", DateTime.Now.ToString("HH:mm:ss"), message);
        }
    }
}
