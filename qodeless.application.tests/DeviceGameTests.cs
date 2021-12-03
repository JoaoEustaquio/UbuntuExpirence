using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using qodeless.application.Interfaces;
using qodeless.application.ViewModels;
using qodeless.domain.Entities;
using qodeless.domain.Enums;
using qodeless.domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace qodeless.application.tests
{
    [TestClass]
    public class DeviceGameServicesTests
    {
        private readonly Mock<IDeviceGameRepository> devicegameRepositoryMock;
        private readonly IDeviceGameAppService devicegameAppService;
        private readonly Mapper mapper;

        public DeviceGameServicesTests()
        {
            devicegameRepositoryMock = new Mock<IDeviceGameRepository>();

            mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<DeviceGame, DeviceGameViewModel>();
                cfg.CreateMap<DeviceGameViewModel, DeviceGame>();
            }));

            devicegameAppService = new DeviceGameAppService(this.mapper, this.devicegameRepositoryMock.Object);
        }

        [TestMethod]
        public async Task AddingDeviceGame_ShouldBeValid()
        {
            // given (arrange)
            var devicegameId = It.IsAny<Guid>();
            var devicegame = new DeviceGameViewModel() { Id = devicegameId, DeviceGameId = "TESTE", GameId="TESTE2" };

            // when (act)
            var validationResult = await devicegameAppService.Add(devicegame);

            // then (assert)
            // 1. Actual list of groups == expected groups
            Assert.IsNotNull(devicegame);
            Assert.IsTrue(validationResult.IsValid);
        }

        [TestMethod]
        public async Task GetDeviceById_ShouldReturnFieldName()
        {
            // given (arrange)
            var entityId = It.IsAny<Guid>();
            var entityName = It.IsAny<string>(); /*string aleatórias*/
            var devicegame = new DeviceGame(entityId) { DeviceGameId = entityName };
            devicegameRepositoryMock.Setup(repository => repository.GetById(entityId)).Returns(devicegame).Verifiable();

            // when (act)
            var devicesFromService = await devicegameAppService.GetById(entityId);

            // then (assert)
            // 1. Actual list of groups == expected groups
            devicegameRepositoryMock.Verify();
            Assert.IsNotNull(devicegame);
            Assert.AreEqual(entityName, devicesFromService.DeviceGameId);
        }

        [TestMethod]
        public async Task AddingDeviceNameNull_ShouldNotBeValid()
        {
            // given (arrange)
            var deviceGameId = It.IsAny<Guid>();
            var devicegame = new DeviceGameViewModel() { Id = deviceGameId, DeviceGameId = "TESTE", GameId = "TESTE2" };

            // when (act)
            var validationResult = await devicegameAppService.Add(devicegame);

            // then (assert)
            // 1. Actual list of groups == expected groups
            Assert.IsNotNull(devicegame);
            // Assert.IsFalse(validationResult.IsValid);
        }

        [TestMethod]
        [DataRow("TESTE1", "TESTE2")]
        [DataRow("TESTE2", "TESTE3")]
        public async Task AddingDeviceFullFilled_ShouldBeOK(string devicegameId, string gameId)
        {
            // given (arrange)
            var deviceGameId = It.IsAny<Guid>();
            var devicegame = new DeviceGameViewModel() { Id = deviceGameId, DeviceGameId = devicegameId, GameId = gameId };

            // when (act)
            var validationResult = await devicegameAppService.Add(devicegame);

            // then (assert)
            // 1. Actual list of groups == expected groups
            Assert.IsNotNull(devicegame);
            Assert.IsTrue(validationResult.IsValid);
        }

        [TestMethod]
        [DataRow("TESTE1", "TESTE2")]
        [DataRow("TESTE2", "TESTE3")]
        public async Task AddingDeviceNameNull_ShouldNotBeValid(string devicegameId, string gameId)
        {
            // given (arrange)
            var deviceGameId = It.IsAny<Guid>();
            var devicegame = new DeviceGameViewModel() { Id = deviceGameId, DeviceGameId=devicegameId, GameId = gameId };

            // when (act)
            var validationResult = await devicegameAppService.Add(devicegame);

            // then (assert)
            // 1. Actual list of groups == expected groups
            Assert.IsNotNull(devicegame);
            //Assert.IsFalse(validationResult.IsValid);
        }

    }
}
