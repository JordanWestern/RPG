using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPG.App.Queries;
using RPG.Domain.Repositories;

namespace RPG.Api.Controllers;

[Route("api/gameLogs")]
[ApiController]
public class GameLogsController(IMediator mediator, IGameLogRepository gameLogRepository) : ControllerBase
{
    [HttpGet("{playerId}")]
    public IActionResult GetGameLogs([FromRoute] Guid playerId, CancellationToken cancellationToken) =>
        Ok(mediator.CreateStream(new GetGameLogsQuery(playerId), cancellationToken));

    [HttpPost("{playerId}")]
    public async Task<IActionResult> DebugGameLogAsync([FromRoute] Guid playerId, [FromBody] string logMessage, CancellationToken cancellationToken)
    {
        await gameLogRepository.CreateLog(Domain.Entities.GameLog.Create(playerId, logMessage), cancellationToken);
        return Created();
    }
}
