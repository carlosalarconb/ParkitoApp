using System;

namespace ParkingLotRental.Application.Dtos
{
    public class ParkingLotDto
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal HourlyRate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
