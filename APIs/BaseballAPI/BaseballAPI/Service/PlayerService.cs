using BaseballAPI.Data;
using BaseballAPI.Models;
using BaseballAPI.Repository;

namespace BaseballAPI.Service
{
    public class PlayerService : IPlayerService
    {

        private ILogger<PlayerService> _logger;
        private IConfiguration _configuration;
        private IRepository _repository;

        public PlayerService(IRepository repostiory, ILogger<PlayerService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;         
            _repository = repostiory;
        }       

        public Player GetPlayer(int playerId)
        {
            Player player = new Player();
            try
            {           
                player = _repository.GetPlayer(playerId);                                   
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return player;
        }
    }
}
