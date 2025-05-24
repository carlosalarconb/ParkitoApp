using AutoMapper;
using FluentAssertions;
using Moq;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Application.Features.ParkingLots.Commands;
using ParkingLotRental.Application.Profiles;
using ParkingLotRental.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotRental.Application.UnitTests.Features.ParkingLots.Commands
{
    public class CreateParkingLotCommandHandlerTests
    {
        private readonly Mock<IParkingLotRepository> _mockParkingLotRepository;
        private readonly IMapper _mapper;

        public CreateParkingLotCommandHandlerTests()
        {
            _mockParkingLotRepository = new Mock<IParkingLotRepository>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidParkingLot_ShouldAddParkingLotToRepository()
        {
            // Arrange
            var command = new CreateParkingLotCommand
            {
                OwnerId = Guid.NewGuid(),
                Address = "123 Main St",
                City = "Test City",
                Country = "Test Country",
                HourlyRate = 10.50m,
                IsAvailable = true
            };

            var handler = new CreateParkingLotCommandHandler(_mockParkingLotRepository.Object, _mapper);

            _mockParkingLotRepository.Setup(repo => repo.AddAsync(It.IsAny<ParkingLot>()))
                .ReturnsAsync((ParkingLot lot) => {
                    lot.Id = Guid.NewGuid(); // Simulate Id generation
                    return lot;
                });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeEmpty();
            _mockParkingLotRepository.Verify(repo => repo.AddAsync(It.Is<ParkingLot>(p =>
                p.OwnerId == command.OwnerId &&
                p.Address == command.Address &&
                p.City == command.City &&
                p.Country == command.Country &&
                p.HourlyRate == command.HourlyRate &&
                p.IsAvailable == command.IsAvailable
            )), Times.Once);
        }
    }
}
