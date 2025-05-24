using ParkingLotRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Contracts.Persistence
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        Task<IReadOnlyList<Reservation>> GetReservationsByUserIdAsync(Guid userId);
        Task<IReadOnlyList<Reservation>> GetReservationsByParkingLotIdAsync(Guid parkingLotId);
    }
}
