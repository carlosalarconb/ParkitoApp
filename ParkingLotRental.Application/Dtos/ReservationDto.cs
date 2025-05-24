using System;

namespace ParkingLotRental.Application.Dtos
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid ParkingLotId { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalCost { get; set; }
    }
}
