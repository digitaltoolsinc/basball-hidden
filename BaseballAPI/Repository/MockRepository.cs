namespace BaseballAPI.Repository
{
    public class MockRepository : IRepository
    {
        public IEnumerable<Player> GetPlayers()
        {
            var players = new List<Player>();
            var player1 = new Player
            {
                FirstName = "Aaron",
                LastName = "Judge",
                BattingAverage = 0.311,
                HomeRuns = 62,
                Rbis = 131,
                Position = "CF",
                TeamId = 2,
                PlayerId = 3
            };
            var player2 = new Player
            {
                FirstName = "Anthony",
                LastName = "Rizzo",
                BattingAverage = 0.224,
                HomeRuns = 32,
                Rbis = 75,
                Position = "1B",
                TeamId = 2,
                PlayerId = 4
            };
            var player3 = new Player
            {
                FirstName = "Kyle",
                LastName = "Schwaber",
                BattingAverage = 0.218,
                HomeRuns = 46,
                Rbis = 94,
                Position = "LF",
                TeamId = 1,
                PlayerId = 1
            };
            var player4 = new Player
            {
                FirstName = "JT",
                LastName = "Realmuto",
                BattingAverage = 0.276,
                HomeRuns = 22,
                Rbis = 84,
                Position = "C",
                TeamId = 1,
                PlayerId = 2
            };
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            return players;
        }

        public IEnumerable<Team> GetTeams()
        {
            var teams = new List<Team>();
            var team1 = new Team
            {
                TeamName = "Phillies",
                TeamMascot = "Phanatic",
                TeamId = 1,
                League = "National",
                Wins = 87,
                Losses = 75
            };
            var team2 = new Team
            {
                TeamName = "Yankees",
                TeamMascot = "New York",
                TeamId = 2,
                League = "American",
                Wins = 99,
                Losses = 63
            };
            teams.Add(team1);
            teams.Add(team2);
            return teams;
        }
    }
}
