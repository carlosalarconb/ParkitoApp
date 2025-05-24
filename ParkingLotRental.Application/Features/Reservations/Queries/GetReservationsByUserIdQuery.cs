using MediatR;
using ParkingLotRental.Application.Dtos;
using System;
using System.Collections.Generic;

namespace ParkingLotRental.Application.Features.Reservations.Queries
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<ReservationDto>>
    {
        public Guid UserId { get; set; }
    }
}
