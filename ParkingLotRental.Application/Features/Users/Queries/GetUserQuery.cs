using MediatR;
using ParkingLotRental.Application.Dtos;
using System;

namespace ParkingLotRental.Application.Features.Users.Queries
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
    }
}
