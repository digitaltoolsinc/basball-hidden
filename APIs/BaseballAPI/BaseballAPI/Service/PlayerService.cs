using BaseballAPI.Data;
using BaseballAPI.Mappers;
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

        public Models.Player GetPlayer(int playerId)
        {
            Models.Player player = new Models.Player();
            try
            {           
                var playerFromDb = _repository.GetPlayer(playerId);
                player = PlayerMapper.MapDataObjectToAPIObject(playerFromDb);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return player;
        }

        public int AddPlayer(Models.Player player)
        {   
            try
            {
                var playerToSaveToDb = PlayerMapper.MapAPIObjectToDataObject(player);
                return _repository.AddPlayer(playerToSaveToDb);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return 0;
        }
    }
}
