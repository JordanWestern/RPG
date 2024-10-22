using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPG.App.Queries;

namespace RPG.Api.Controllers;

[Route("api/maps")]
[ApiController]
public class MapsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public IActionResult GetMaps(CancellationToken cancellationToken) => 
        Ok(mediator.CreateStream(new GetMapsQuery(), cancellationToken));
}
