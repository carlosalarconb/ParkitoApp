using AutoMapper;
using FluentAssertions;
using Moq;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Application.Features.Users.Commands;
using ParkingLotRental.Application.Profiles;
using ParkingLotRental.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotRental.Application.UnitTests.Features.Users.Commands
{
    public class RegisterUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandlerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidUser_ShouldAddUserToRepository()
        {
            // Arrange
            var command = new RegisterUserCommand
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "Password123"
            };

            var handler = new RegisterUserCommandHandler(_mockUserRepository.Object, _mapper);

            _mockUserRepository.Setup(repo => repo.AddAsync(It.IsAny<User>()))
                .ReturnsAsync((User user) => {
                    user.Id = Guid.NewGuid(); // Simulate Id generation
                    return user;
                });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeEmpty();
            _mockUserRepository.Verify(repo => repo.AddAsync(It.Is<User>(u => 
                u.FirstName == command.FirstName &&
                u.LastName == command.LastName &&
                u.Email == command.Email 
                // Password hashing is not tested here, only that the command data is mapped
            )), Times.Once);
        }
    }
}
