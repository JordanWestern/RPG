using Microsoft.AspNetCore.Mvc;
using RPG.Domain.Events;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPG.Api.Controllers;

[Route("api/debug")]
[ApiController]
public class DebugController(IGameEventService gameEventService) : ControllerBase
{
    [HttpPost("/emitGameEvent")]
    public async Task<IActionResult> EmitGameEvent([FromBody] string message, CancellationToken cancellationToken)
    {
        await gameEventService.EmitGameEvent(message, cancellationToken);

        return Ok();
    }
}
