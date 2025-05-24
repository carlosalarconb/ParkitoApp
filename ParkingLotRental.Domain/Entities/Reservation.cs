using System;

namespace ParkingLotRental.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid ParkingLotId { get; set; } // Foreign key to ParkingLot
        public Guid UserId { get; set; } // Foreign key to User
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalCost { get; set; }
    }
}
