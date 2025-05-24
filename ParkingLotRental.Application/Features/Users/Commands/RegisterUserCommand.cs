using MediatR;
using ParkingLotRental.Application.Dtos;
using System;

namespace ParkingLotRental.Application.Features.Users.Commands
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
