using Microsoft.AspNetCore.Mvc;
using RPG.App.Contracts;
using RPG.App.Services;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPG.Api.Controllers;

[Route("api/player")]
[ApiController]
public class PlayerController(IPlayerService playerService) : ControllerBase
{
    //[HttpGet(Name = "playerId")]
    //public IActionResult Get([FromRoute] Guid playerId, CancellationToken cancellationToken)
    //{
    //    playerService.GetExistingPlayer(playerId, cancellationToken);
    //}

    [HttpPost()]
    public async Task<IActionResult> CreatePlayer([FromBody][Required] NewPlayer newPlayer, CancellationToken cancellationToken)
    {
        if (!newPlayer.IsValid())
        {
            return BadRequest(newPlayer.Name);
        }

        var player = await playerService.CreateNewPlayer(newPlayer, cancellationToken);
        return Created(new Uri($"api/player/{player.Id}", UriKind.Relative), player);
    }
}
