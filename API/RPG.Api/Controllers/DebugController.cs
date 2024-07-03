using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RPG.Api.Events;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPG.Api.Controllers
{
    [Route("api/debug")]
    [ApiController]
    public class DebugController : ControllerBase
    {
        private readonly IHubContext<GameEventHub> _hubContext;

        public DebugController(IHubContext<GameEventHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("/gameEvents")]
        public async Task<IActionResult> EmitGameEvent([FromBody] string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveLog", DateTime.Now.ToString("HH:mm:ss"), message);

            return Ok();
        }
    }
}
