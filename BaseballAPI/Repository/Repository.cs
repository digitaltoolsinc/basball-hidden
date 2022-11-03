using BaseballAPI.Service;

namespace BaseballAPI.Repository
{
    public class Repository : IRepository
    {
        //would not want to do this in real life because then you would be getting EVERYTHING from the database. you would need to change the linq queries

        private ILogger<TeamService> _logger;
        private IConfiguration _configuration;
        private string _connectionString;

        public Repository(ILogger<TeamService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString");
        }

        public IEnumerable<Player> GetPlayers()
        {
            var players = new List<Player>();
            
            using (var context = new BaseballContext(_connectionString))
            {
                players = context.Players.ToList();
            }
            return players;
        }

        public IEnumerable<Team> GetTeams()
        {
            var teams = new List<Team>();

            using (var context = new BaseballContext(_connectionString))
            {
                teams = context.Teams.ToList();
            }
            return teams;
        }

    }
}
