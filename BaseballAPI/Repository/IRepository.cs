using BaseballAPI.Data;

namespace BaseballAPI.Repository
{
    public interface IRepository
    {
        IEnumerable<Player> GetPlayers();

        IEnumerable<Team> GetTeams();

        Player GetPlayer(int playerId);
    }
}