using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingLotRental.Application.Features.ParkingLots.Commands;
using ParkingLotRental.Application.Features.ParkingLots.Queries;
using System;
using System.Threading.Tasks;

namespace ParkingLotRental.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingLotsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParkingLot([FromBody] CreateParkingLotCommand command)
        {
            var parkingLotId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetParkingLotById), new { id = parkingLotId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParkingLot(Guid id, [FromBody] UpdateParkingLotCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParkingLotById(Guid id)
        {
            var query = new GetParkingLotByIdQuery { ParkingLotId = id };
            var parkingLot = await _mediator.Send(query);
            if (parkingLot == null)
            {
                return NotFound();
            }
            return Ok(parkingLot);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableParkingLots()
        {
            var query = new GetAvailableParkingLotsQuery();
            var parkingLots = await _mediator.Send(query);
            return Ok(parkingLots);
        }
    }
}
