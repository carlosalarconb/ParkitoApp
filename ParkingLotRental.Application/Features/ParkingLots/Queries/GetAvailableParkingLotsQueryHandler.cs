using AutoMapper;
using MediatR;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Application.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Features.ParkingLots.Queries
{
    public class GetAvailableParkingLotsQueryHandler : IRequestHandler<GetAvailableParkingLotsQuery, IEnumerable<ParkingLotDto>>
    {
        private readonly IParkingLotRepository _parkingLotRepository;
        private readonly IMapper _mapper;

        public GetAvailableParkingLotsQueryHandler(IParkingLotRepository parkingLotRepository, IMapper mapper)
        {
            _parkingLotRepository = parkingLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParkingLotDto>> Handle(GetAvailableParkingLotsQuery request, CancellationToken cancellationToken)
        {
            var parkingLots = await _parkingLotRepository.GetAvailableParkingLotsAsync();
            return _mapper.Map<IEnumerable<ParkingLotDto>>(parkingLots);
        }
    }
}
