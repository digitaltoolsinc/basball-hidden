using BaseballAPI.Models;
using System.Collections.Generic;

namespace BaseballAPI.Service
{
    public interface ITeamService
    {
        IEnumerable<Player> GetPlayersOnTeam(string teamName);

        int GetTeamID(string teamName);

    }
}