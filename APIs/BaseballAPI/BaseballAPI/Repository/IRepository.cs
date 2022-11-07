using BaseballAPI.Data;

namespace BaseballAPI.Repository
{
    public interface IRepository
    {
        IEnumerable<Player> GetPlayersOnTeam();

        IEnumerable<Team> GetTeams();

        Player GetPlayer(int playerId);
    }
}