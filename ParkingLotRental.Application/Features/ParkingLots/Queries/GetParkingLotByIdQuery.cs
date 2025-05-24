using MediatR;
using ParkingLotRental.Application.Dtos;
using System;

namespace ParkingLotRental.Application.Features.ParkingLots.Queries
{
    public class GetParkingLotByIdQuery : IRequest<ParkingLotDto>
    {
        public Guid ParkingLotId { get; set; }
    }
}
