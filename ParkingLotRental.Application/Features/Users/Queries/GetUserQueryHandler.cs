using AutoMapper;
using MediatR;
using ParkingLotRental.Application.Contracts.Persistence;
using ParkingLotRental.Application.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotRental.Application.Features.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            return _mapper.Map<UserDto>(user);
        }
    }
}
