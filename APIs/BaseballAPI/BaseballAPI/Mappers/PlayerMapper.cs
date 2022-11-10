using BaseballAPI.Models;

namespace BaseballAPI.Mappers
{
    //can use automapper or refelction, but keeping it simple for now
    public static class PlayerMapper
    {
        public static Player MapDataObjectToAPIObject(BaseballAPI.Data.Player player)
        {
            return new BaseballAPI.Models.Player
            {
                BattingAverage = player.BattingAverage,
                FirstName = player.FirstName,
                LastName = player.LastName,
                HomeRuns = player.HomeRuns,
                PlayerId = player.PlayerId,
                Position = player.Position,
                Rbis = player.Rbis,
                TeamId = player.TeamId
            };
        }

        //there's an obvious problem with this, hint it's an id problem
        public static BaseballAPI.Data.Player MapAPIObjectToDataObject(BaseballAPI.Models.Player player)
        {
            return new BaseballAPI.Data.Player
            {
                BattingAverage = player.BattingAverage,
                FirstName = player.FirstName,
                LastName = player.LastName,
                HomeRuns = player.HomeRuns,
                PlayerId = player.PlayerId,
                Position = player.Position,
                Rbis = player.Rbis,
                TeamId = player.TeamId
            };
        }
    }
}
