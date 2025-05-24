using AutoMapper;
using MediatR;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Features.ParkingLots.Commands
{
    public class CreateParkingLotCommandHandler : IRequestHandler<CreateParkingLotCommand, Guid>
    {
        private readonly IParkingLotRepository _parkingLotRepository;
        private readonly IMapper _mapper;

        public CreateParkingLotCommandHandler(IParkingLotRepository parkingLotRepository, IMapper mapper)
        {
            _parkingLotRepository = parkingLotRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateParkingLotCommand request, CancellationToken cancellationToken)
        {
            var parkingLot = _mapper.Map<ParkingLot>(request);
            var newParkingLot = await _parkingLotRepository.AddAsync(parkingLot);
            return newParkingLot.Id;
        }
    }
}
