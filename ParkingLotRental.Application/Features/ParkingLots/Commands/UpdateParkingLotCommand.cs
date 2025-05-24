using MediatR;
using System;

namespace ParkingLotRental.Application.Features.ParkingLots.Commands
{
    public class UpdateParkingLotCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal HourlyRate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
