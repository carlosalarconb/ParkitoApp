using MediatR;
using System;

namespace ParkingLotRental.Application.Features.Reservations.Commands
{
    public class CreateReservationCommand : IRequest<Guid>
    {
        public Guid ParkingLotId { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalCost { get; set; } // This could be calculated in the handler
    }
}
