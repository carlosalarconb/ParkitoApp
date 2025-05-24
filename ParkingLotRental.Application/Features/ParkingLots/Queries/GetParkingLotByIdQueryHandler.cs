using AutoMapper;
using MediatR;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Application.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Features.ParkingLots.Queries
{
    public class GetParkingLotByIdQueryHandler : IRequestHandler<GetParkingLotByIdQuery, ParkingLotDto>
    {
        private readonly IParkingLotRepository _parkingLotRepository;
        private readonly IMapper _mapper;

        public GetParkingLotByIdQueryHandler(IParkingLotRepository parkingLotRepository, IMapper mapper)
        {
            _parkingLotRepository = parkingLotRepository;
            _mapper = mapper;
        }

        public async Task<ParkingLotDto> Handle(GetParkingLotByIdQuery request, CancellationToken cancellationToken)
        {
            var parkingLot = await _parkingLotRepository.GetByIdAsync(request.ParkingLotId);
            return _mapper.Map<ParkingLotDto>(parkingLot);
        }
    }
}
