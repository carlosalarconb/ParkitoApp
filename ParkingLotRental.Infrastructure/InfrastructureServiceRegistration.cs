using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Infrastructure.Persistence.DbContexts;
using ParkingLotRental.Infrastructure.Persistence.Repositories;

namespace ParkingLotRental.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ParkingLotRentalDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ParkingLotRentalConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IParkingLotRepository, ParkingLotRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            return services;
        }
    }
}
