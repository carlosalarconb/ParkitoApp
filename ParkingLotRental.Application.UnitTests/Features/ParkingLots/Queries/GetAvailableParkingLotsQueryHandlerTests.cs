using AutoMapper;
using FluentAssertions;
using Moq;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Application.Dtos;
using ParkingLotRental.Application.Features.ParkingLots.Queries;
using ParkingLotRental.Application.Profiles;
using ParkingLotRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotRental.Application.UnitTests.Features.ParkingLots.Queries
{
    public class GetAvailableParkingLotsQueryHandlerTests
    {
        private readonly Mock<IParkingLotRepository> _mockParkingLotRepository;
        private readonly IMapper _mapper;

        public GetAvailableParkingLotsQueryHandlerTests()
        {
            _mockParkingLotRepository = new Mock<IParkingLotRepository>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldReturnAvailableParkingLots()
        {
            // Arrange
            var availableParkingLots = new List<ParkingLot>
            {
                new ParkingLot { Id = Guid.NewGuid(), Address = "1 Main St", IsAvailable = true },
                new ParkingLot { Id = Guid.NewGuid(), Address = "2 Main St", IsAvailable = true }
            };

            _mockParkingLotRepository.Setup(repo => repo.GetAvailableParkingLotsAsync())
                .ReturnsAsync(availableParkingLots);

            var handler = new GetAvailableParkingLotsQueryHandler(_mockParkingLotRepository.Object, _mapper);
            var query = new GetAvailableParkingLotsQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(availableParkingLots.Count);
            result.Should().BeAssignableTo<IEnumerable<ParkingLotDto>>();
            _mockParkingLotRepository.Verify(repo => repo.GetAvailableParkingLotsAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenNoAvailableParkingLots_ShouldReturnEmptyList()
        {
            // Arrange
            var emptyList = new List<ParkingLot>();
            _mockParkingLotRepository.Setup(repo => repo.GetAvailableParkingLotsAsync())
                .ReturnsAsync(emptyList);
            
            var handler = new GetAvailableParkingLotsQueryHandler(_mockParkingLotRepository.Object, _mapper);
            var query = new GetAvailableParkingLotsQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
            _mockParkingLotRepository.Verify(repo => repo.GetAvailableParkingLotsAsync(), Times.Once);
        }
    }
}
