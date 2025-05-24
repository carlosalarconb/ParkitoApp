using MediatR;
using ParkingLotRental.Application.Dtos;
using System.Collections.Generic;

namespace ParkingLotRental.Application.Features.ParkingLots.Queries
{
    public class GetAvailableParkingLotsQuery : IRequest<IEnumerable<ParkingLotDto>>
    {
    }
}
