using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingLotRental.Application.Features.Reservations.Commands;
using ParkingLotRental.Application.Features.Reservations.Queries;
using System;
using System.Threading.Tasks;

namespace ParkingLotRental.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)
        {
            var reservationId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetReservationById), new { id = reservationId }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(Guid id)
        {
            var query = new GetReservationByIdQuery { ReservationId = id };
            var reservation = await _mediator.Send(query);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }
    }
}
