using Application.DTO;
using Application.Interface;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers;

[ApiController]
[Route( "/api/reservations" )]
public class ReservationsController : ControllerBase
{
    private readonly IReservartionService _reservertionService;
    private readonly IUnitOfWork _unitOfWork;

    public ReservationsController( IReservartionService reservertionService,
        IUnitOfWork unitOfWork )
    {
        _reservertionService = reservertionService;
        _unitOfWork = unitOfWork;
    }

    [HttpGet( "{id}" )]
    public async Task<IActionResult> GetReservation( int id )
    {
        ReservationResponseDTO reservationDTO = await _reservertionService.GetById( id );
        if ( reservationDTO == null )
        {
            return NotFound();
        }
        return Ok( reservationDTO );
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation( [FromBody] ReservationRequestDTO reservationDTO )
    {
        try
        {
            await _reservertionService.CreateReservation( reservationDTO );
            await _unitOfWork.CommitAsync();
            return Ok( new { Messege = "Reservationa created successefully." } );
        }
        catch ( InvalidOperationException ex )
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetReservations( [FromQuery] ReservationFilterDTO reservationFilter )
    {
        List<ReservationResponseDTO> reservationDTO = await _reservertionService.GetAll( reservationFilter );
        if ( reservationDTO == null && reservationDTO.Count == 0 )
        {
            return NoContent();
        }
        return Ok( Ok( reservationDTO ) );
    }
}
