using Microsoft.AspNetCore.Mvc;

namespace RPG.Api.Controllers
{
    [Route("api/info")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        [HttpGet("ready")]
        public IActionResult Ready() => Ok();
    }
}
