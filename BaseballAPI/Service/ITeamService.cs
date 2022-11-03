using BaseballAPI.Models;
using System.Collections.Generic;

namespace BaseballAPI.Service
{
    public interface ITeamService
    {
        IEnumerable<PlayerAPI> GetPlayers(string teamName);

        int GetTeamID(string teamName);
    }
}