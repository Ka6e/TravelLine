using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers;

[ApiController]
[Route( "/api/reservations" )]
public class ReservationsController : ControllerBase
{
    private readonly IReservertionService _reservertionService;

    public ReservationsController( IReservertionService reservertionService )
    {
        _reservertionService = reservertionService;
    }

    [HttpGet( "{id}" )]
    public async Task<IActionResult> GetReservation( int id )
    {
        ReservationDTO reservationDTO = await _reservertionService.GetById( id );
        if ( reservationDTO == null )
        {
            return NotFound();
        }
        return Ok( reservationDTO );
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation( [FromBody] ReservationDTO reservationDTO )
    {
        try
        {
            await _reservertionService.CreateReservation( reservationDTO );
            return Ok(new {Messege = "Reservationa created successefully."});
        }
        catch ( InvalidOperationException ex )
        {
            return BadRequest( ex.Message );
        }
    }

    //[HttpGet]
    //public async Task<IActionResult> GetReservations( [FromQuery] ReservationFilterDTO reservationFilter )
    //{
    //    List<ReservationDTO> reservationDTOs = await _reservertionService.GetAll( reservationFilter );
    //}
}
