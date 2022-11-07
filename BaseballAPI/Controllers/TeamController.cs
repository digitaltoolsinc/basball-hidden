using BaseballAPI.Models;
using BaseballAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BaseballAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {     

        private readonly ILogger<TeamController> _logger;
        private ITeamService _teamService;

        public TeamController(ITeamService teamService, ILogger<TeamController> logger)
        {
            _logger = logger;
            _teamService = teamService;
        }

        [HttpGet]
        public IEnumerable<PlayerAPI> GetPlayers(string teamName)
        {
           var players = _teamService.GetPlayers(teamName);
           return players;          

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        [Route("different/route")]
        public IActionResult GetPlayersAnotherWay(string teamName)
        {
            try
            {
                var players = _teamService.GetPlayers(teamName);
                if (players.Count() > 0)
                    return Ok(players);
                else
                    return NoContent();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Oops! An error happened!");
            }

            return BadRequest("Oops! An error happened!");
        }
    }
}