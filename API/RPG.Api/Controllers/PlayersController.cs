using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPG.App.Commands;
using RPG.App.Contracts;
using RPG.App.Queries;

namespace RPG.Api.Controllers;

[Route("api/players")]
[ApiController]
public class PlayersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public IActionResult GetExistingPlayers(CancellationToken cancellationToken) => 
        Ok(mediator.CreateStream(new GetPlayersQuery(), cancellationToken));

    [HttpPost()]
    public async Task<IActionResult> CreatePlayer([FromBody] NewPlayer newPlayer, CancellationToken cancellationToken)
    {
        if (!newPlayer.IsValid())
        {
            return BadRequest(newPlayer.Name);
        }

        var player = await mediator.Send(new CreatePlayerCommand(newPlayer), cancellationToken);
        return Created(new Uri($"api/player/{player.Id}", UriKind.Relative), player);
    }
}
