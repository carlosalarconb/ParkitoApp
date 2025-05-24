using AutoMapper;
using MediatR;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Features.ParkingLots.Commands
{
    public class UpdateParkingLotCommandHandler : IRequestHandler<UpdateParkingLotCommand>
    {
        private readonly IParkingLotRepository _parkingLotRepository;
        private readonly IMapper _mapper;

        public UpdateParkingLotCommandHandler(IParkingLotRepository parkingLotRepository, IMapper mapper)
        {
            _parkingLotRepository = parkingLotRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateParkingLotCommand request, CancellationToken cancellationToken)
        {
            var parkingLotToUpdate = await _parkingLotRepository.GetByIdAsync(request.Id);
            if (parkingLotToUpdate == null)
            {
                // Handle not found scenario, perhaps throw an exception
                return Unit.Value; 
            }

            _mapper.Map(request, parkingLotToUpdate);
            await _parkingLotRepository.UpdateAsync(parkingLotToUpdate);
            return Unit.Value;
        }
    }
}
