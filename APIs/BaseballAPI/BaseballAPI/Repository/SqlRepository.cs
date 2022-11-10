﻿using BaseballAPI.Data;
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

        public SqlRepository(ILogger<SqlRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString");
        }

        public IEnumerable<Player> GetPlayersOnTeam()
        {
            var players = new List<Player>();
            
            using (var context = new BaseballContext(_connectionString))
            {
                players = context.Players.ToList();
            }
            return players;
        }



        public Player GetPlayer(int playerId)
        {
            var player = new Player();

            using (var context = new BaseballContext(_connectionString))
            {
                player = context.Players.FirstOrDefault(i => i.PlayerId == playerId);
            }
            return player;
        }

        public int AddPlayer(Player player)
        {
            try
            {
                using (var context = new BaseballContext(_connectionString))
                {
                    return context.Database.ExecuteSqlInterpolated($"dbo.InsertPlayer {player.FirstName}, {player.LastName}, {player.TeamId}, {player.BattingAverage}, {player.HomeRuns}, {player.Rbis}, {player.Position}");
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return 0;
            }
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
