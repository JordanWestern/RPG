using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPG.App.Queries;

namespace RPG.Api.Controllers;

[Route("api/gameLogs")]
[ApiController]
public class GameLogsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{playerId}")]
    public IActionResult GetGameLogs([FromRoute] Guid playerId, CancellationToken cancellationToken) =>
        Ok(mediator.CreateStream(new GetGameLogsQuery(playerId), cancellationToken));
}
