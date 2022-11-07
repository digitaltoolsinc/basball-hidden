using BaseballAPI.Data;
using BaseballAPI.Models;
using BaseballAPI.Repository;

namespace BaseballAPI.Service
{
    public class TeamService : ITeamService
    {
        private ILogger<TeamService> _logger;  
        private IConfiguration _configuration;
        private string _connectionString;
        private IRepository _repository;
        
        public TeamService(IRepository repostiory, ILogger<TeamService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString");
            _repository = repostiory;
        }

        public IEnumerable<PlayerAPI> GetPlayers(string teamName)
        {
            List<PlayerAPI> playersAPI = new List<PlayerAPI>();
            try
            {
                int id = GetTeamID(teamName);
                if (id > 0)
                {
                    List<Player> players = new List<Player>();                    
                    players = _repository.GetPlayers().Where(i => i.TeamId == id).ToList();
                    
                    foreach (var p in players)
                    {
                        PlayerAPI playerAPI = new PlayerAPI
                        {
                            BattingAverage = p.BattingAverage,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            HomeRuns = p.HomeRuns,
                            Position = p.Position,
                            Rbis = p.Rbis,
                            TeamName = teamName
                        };
                        playersAPI.Add(playerAPI);
                    }
                }                
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return playersAPI;
         }

        public int GetTeamID(string teamName)
        {
            try
            {
                Team team = new Team();               
                team = _repository.GetTeams().FirstOrDefault(i => i.TeamName == teamName);                
                if (team != null)
                    return team.TeamId;
                return -1;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return -1;
            }

        }
    }
}
