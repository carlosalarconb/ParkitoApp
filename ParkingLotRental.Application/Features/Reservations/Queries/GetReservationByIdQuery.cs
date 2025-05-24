using MediatR;
using ParkingLotRental.Application.Dtos;
using System;

namespace ParkingLotRental.Application.Features.Reservations.Queries
{
    public class GetReservationByIdQuery : IRequest<ReservationDto>
    {
        public Guid ReservationId { get; set; }
    }
}
