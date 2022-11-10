using BaseballAPI.Data;
using BaseballAPI.Repository;
using BaseballAPI.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BaseballAPI.Tests.Service
{
    [TestFixture()]
    internal class PlayerServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private PlayerService _playerService;
        private Mock<ILogger<PlayerService>> _mockLogger;
        private Mock<IConfiguration> _mockConfiguration;
        private Player _player;

        [OneTimeSetUp]
        public void Setup()
        {
            _player = new Player
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
            _mockRepository = new Mock<IRepository>();
            _mockLogger = new Mock<ILogger<PlayerService>>();
            _mockConfiguration = new Mock<IConfiguration>();
            _playerService = new PlayerService(_mockRepository.Object, _mockLogger.Object, _mockConfiguration.Object);
        }

        [Test]
        public void PlayerExists()
        {
            //Arrange 
            _mockRepository.Setup(i => i.GetPlayer(3)).Returns(_player);

            //Act
            var result = _playerService.GetPlayer(3);
            

            //Assert
            Assert.IsTrue(result.PlayerId == _player.PlayerId);
        }

        [Test]
        public void PlayerDoesNotExist()
        {
            //Arrange 
            _mockRepository.Setup(i => i.GetPlayer(3)).Returns(_player);

            //Act
            var result = _playerService.GetPlayer(99);

            //Assert
            Assert.IsTrue(result == null);
        }
    }
}
