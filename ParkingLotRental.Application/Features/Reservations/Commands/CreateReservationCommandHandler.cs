using AutoMapper;
using MediatR;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Features.Reservations.Commands
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = _mapper.Map<Reservation>(request);
            // Add logic to calculate TotalCost if not provided or to validate it
            var newReservation = await _reservationRepository.AddAsync(reservation);
            return newReservation.Id;
        }
    }
}
