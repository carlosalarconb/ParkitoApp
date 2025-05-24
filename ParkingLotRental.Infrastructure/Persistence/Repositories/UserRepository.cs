using Microsoft.EntityFrameworkCore;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Domain.Entities;
using ParkingLotRental.Infrastructure.Persistence.DbContexts;
using System;
using System.Threading.Tasks;

namespace ParkingLotRental.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ParkingLotRentalDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
