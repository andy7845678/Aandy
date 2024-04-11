using Aandy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aandy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AandyController : ControllerBase
    {
        private readonly ILogger<AandyController> _logger;
        public AandyController(ILogger<AandyController> logger)
        {
            _logger = logger;
        }

        // POST api/<AandyController>
        [HttpPost]
        public async Task<IActionResult> Post(RequestModel request)
        {
            ResponseModel<string> response = new ResponseModel<string>();
            var RequestPath = $"?gameId={request.GameId}&account={request.ClubId}";
            if (request.Platform.ToLower() == "rsg")
            {
                response.Url = $"http://game.rsg.com{RequestPath}";
            }
            else if (request.Platform.ToLower() == "rcg")
            {
                response.Url = $"http://game.rcg.com{RequestPath}";
            }
            else {
                return BadRequest();
            }
            return Ok(response);
        }

    }
}
