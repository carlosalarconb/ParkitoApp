using AutoMapper;
using MediatR;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Features.Reservations.Queries
{
    public class GetReservationsByUserIdQueryHandler : IRequestHandler<GetReservationsByUserIdQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GetReservationsByUserIdQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationDto>> Handle(GetReservationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetReservationsByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }
    }
}
