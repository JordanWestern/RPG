using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPG.App.Contracts;
using RPG.App.Requests;
using RPG.App.Services;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPG.Api.Controllers;

[Route("api/players")]
[ApiController]
public class PlayersController(IPlayerService playerService, IMediator mediator) : ControllerBase
{
    [HttpGet]
    public IActionResult GetExistingPlayers(CancellationToken cancellationToken) => 
        Ok(playerService.GetExistingPlayers(cancellationToken));

    [HttpPost()]
    public async Task<IActionResult> CreatePlayer([FromBody][Required] NewPlayer newPlayer, CancellationToken cancellationToken)
    {
        if (!newPlayer.IsValid())
        {
            return BadRequest(newPlayer.Name);
        }

        var player = await mediator.Send(new CreatePlayerRequest(newPlayer), cancellationToken);
        return Created(new Uri($"api/player/{player.Id}", UriKind.Relative), player);
    }
}
