using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPG.App.Contracts;
using RPG.App.Queries;
using RPG.App.Requests;
using System.ComponentModel.DataAnnotations;

namespace RPG.Api.Controllers;

[Route("api/players")]
[ApiController]
public class PlayersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public IActionResult GetExistingPlayers(CancellationToken cancellationToken) => 
        Ok(mediator.CreateStream(new GetPlayersQuery(), cancellationToken));

    [HttpPost()]
    public async Task<IActionResult> CreatePlayer([FromBody][Required] NewPlayer newPlayer, CancellationToken cancellationToken)
    {
        // TODO: use meadiatr pipeline behaviour to validate and throw, use .NET exception handling middleware to catch and convert to problem details.
        if (!newPlayer.IsValid())
        {
            return BadRequest(newPlayer.Name);
        }

        var player = await mediator.Send(new CreatePlayerCommand(newPlayer), cancellationToken);
        return Created(new Uri($"api/player/{player.Id}", UriKind.Relative), player);
    }
}
