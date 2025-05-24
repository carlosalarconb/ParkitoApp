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
    public class ParkingLotRepository : GenericRepository<ParkingLot>, IParkingLotRepository
    {
        public ParkingLotRepository(ParkingLotRentalDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<ParkingLot>> GetAvailableParkingLotsAsync()
        {
            return await _dbContext.ParkingLots
                                   .Where(p => p.IsAvailable)
                                   .ToListAsync();
        }
    }
}
