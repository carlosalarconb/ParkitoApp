using ParkingLotRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Contracts.Persistence
{
    public interface IParkingLotRepository : IGenericRepository<ParkingLot>
    {
        Task<IReadOnlyList<ParkingLot>> GetAvailableParkingLotsAsync();
    }
}
