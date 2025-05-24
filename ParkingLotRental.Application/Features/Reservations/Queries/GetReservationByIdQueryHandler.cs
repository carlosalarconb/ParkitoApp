using AutoMapper;
using MediatR;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Application.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Features.Reservations.Queries
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GetReservationByIdQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationId);
            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}
