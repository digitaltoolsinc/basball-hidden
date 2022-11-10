
using BaseballAPI.Models;

namespace BaseballAPI.Service
{
    public interface IPlayerService
    {

        Player GetPlayer(int playerId);

        int AddPlayer(Player player);

    }
}
