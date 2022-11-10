using BaseballAPI.Data;
using BaseballAPI.Models;
using BaseballAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Player = BaseballAPI.Models.Player;

namespace BaseballAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {

        private readonly ILogger<PlayerController> _logger;
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService, ILogger<PlayerController> logger)
        {
            _logger = logger;
            _playerService = playerService;
        }
 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        public IActionResult GetPlayer(int playerId)
        {
            try
            {
                var player = _playerService.GetPlayer(playerId);
                if (player != null)
                    return Ok(player);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Oops! An error happened!");
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        public IActionResult AddPlayer(Player player)
        {
            try
            {
                //need some validations somwhere
                if (_playerService.AddPlayer(player) == 1)
                {
                    _logger.LogInformation("player added");
                    return Ok("player Added!");
                }
                else
                {
                    _logger.LogInformation("error!.");
                    return BadRequest("error!");
                }
            

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Oops! An error happened!");
            }
        }
    }
}