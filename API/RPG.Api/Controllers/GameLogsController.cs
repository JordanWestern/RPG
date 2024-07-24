using Microsoft.AspNetCore.Mvc;
using RPG.App.Services;

namespace RPG.Api.Controllers;

[Route("api/gameLogs")]
[ApiController]
public class GameLogsController(IGameLogService gameLogService) : ControllerBase
{
    [HttpGet("{playerId}")]
    public IActionResult GetGameLogs([FromRoute] Guid playerId, CancellationToken cancellationToken) =>
        Ok(gameLogService.GetGameLogs(playerId, cancellationToken));
}
