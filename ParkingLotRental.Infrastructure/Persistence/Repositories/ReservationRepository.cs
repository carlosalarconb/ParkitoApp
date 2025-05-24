using Microsoft.EntityFrameworkCore;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Domain.Entities;
using ParkingLotRental.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLotRental.Infrastructure.Persistence.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ParkingLotRentalDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Reservation>> GetReservationsByParkingLotIdAsync(Guid parkingLotId)
        {
            return await _dbContext.Reservations
                                   .Where(r => r.ParkingLotId == parkingLotId)
                                   .ToListAsync();
        }

        public async Task<IReadOnlyList<Reservation>> GetReservationsByUserIdAsync(Guid userId)
        {
            return await _dbContext.Reservations
                                   .Where(r => r.UserId == userId)
                                   .ToListAsync();
        }
    }
}
