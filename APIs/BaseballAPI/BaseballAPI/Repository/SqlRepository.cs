using BaseballAPI.Data;
using BaseballAPI.Models;
using BaseballAPI.Service;
using Microsoft.EntityFrameworkCore;
using Player = BaseballAPI.Data.Player;

namespace BaseballAPI.Repository
{
    public class SqlRepository : IRepository
    {
        //would not want to do this in real life because then you would be getting EVERYTHING from the database. you would need to change the linq queries

        private ILogger<SqlRepository> _logger;
        private IConfiguration _configuration;
        private string _connectionString;
        private BaseballContext _context;

        public SqlRepository(ILogger<SqlRepository> logger, IConfiguration configuration, BaseballContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString");
            _context = context;
        }

        public IEnumerable<Player> GetPlayersOnTeam()
        {           
            return _context.Players.ToList();           
        }

        public Player GetPlayer(int playerId)
        {           
            return _context.Players.FirstOrDefault(i => i.PlayerId == playerId);          
        }

        public int AddPlayer(Player player)
        {
            try
            {            
               return _context.Database.ExecuteSqlInterpolated($"dbo.InsertPlayer {player.FirstName}, {player.LastName}, {player.TeamId}, {player.BattingAverage}, {player.HomeRuns}, {player.Rbis}, {player.Position}");              
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return 0;
            }
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

    }
}
