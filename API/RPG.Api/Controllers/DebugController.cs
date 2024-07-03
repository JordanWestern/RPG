using Microsoft.AspNetCore.Mvc;
using RPG.App.Events;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPG.Api.Controllers;

[Route("api/debug")]
[ApiController]
public class DebugController : ControllerBase
{
    private readonly IGameEventService _gameEventService;

    public DebugController(IGameEventService gameEventService)
    {
        _gameEventService = gameEventService;
    }

    [HttpPost("/emitGameEvent")]
    public async Task<IActionResult> EmitGameEvent([FromBody] string message, CancellationToken cancellationToken)
    {
        await _gameEventService.EmitGameEvent(message, cancellationToken);

        return Ok();
    }
}
