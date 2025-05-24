using System.Collections.Generic;

namespace ParkingLotRental.Domain.Entities
{
    public class ParkingLot
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; } // Foreign key to User
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal HourlyRate { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
