using AutoMapper;
using ParkingLotRental.Application.Dtos;
using ParkingLotRental.Application.Features.ParkingLots.Commands;
using ParkingLotRental.Application.Features.Reservations.Commands;
using ParkingLotRental.Application.Features.Users.Commands;
using ParkingLotRental.Domain.Entities;

namespace ParkingLotRental.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mappings
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<RegisterUserCommand, User>();

            // ParkingLot Mappings
            CreateMap<ParkingLot, ParkingLotDto>().ReverseMap();
            CreateMap<CreateParkingLotCommand, ParkingLot>();
            CreateMap<UpdateParkingLotCommand, ParkingLot>();

            // Reservation Mappings
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<CreateReservationCommand, Reservation>();
        }
    }
}
