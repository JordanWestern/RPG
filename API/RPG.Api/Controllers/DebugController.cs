using Microsoft.AspNetCore.Mvc;
using RPG.Domain.Events;
using RPG.Domain.Factories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPG.Api.Controllers;

[Route("api/debug")]
[ApiController]
public class DebugController(IGameEventService gameEventService, IGameLogFactory gameLogFactory) : ControllerBase
{
    [HttpPost("/emitGameEvent/{playerId}")]
    public async Task<IActionResult> EmitGameEvent([FromRoute] Guid playerId, [FromBody] string message, CancellationToken cancellationToken)
    {
        var log = gameLogFactory.Create(playerId, message);
        await gameEventService.EmitGameEvent(log, cancellationToken);
        return Ok();
    }
}
    