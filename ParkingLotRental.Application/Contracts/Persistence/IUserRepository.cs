using ParkingLotRental.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
