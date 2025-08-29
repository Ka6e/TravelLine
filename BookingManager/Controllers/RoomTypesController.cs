using Application.DTO;
using Application.Interface;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers;

[ApiController]
[Route( "api/roomtypes" )]
public class RoomTypesController : ControllerBase
{
    private readonly IRoomTypeService _roomTypeService;
    private readonly IUnitOfWork _unitOfWork;

    public RoomTypesController( IRoomTypeService roomTypeService, IUnitOfWork unitOfWork )
    {
        _roomTypeService = roomTypeService;
        _unitOfWork = unitOfWork;
    }

    [HttpGet( "{id}" )]
    public async Task<IActionResult> GetRoom( int id )
    {
        var roomType = await _roomTypeService.GetById( id );
        if ( roomType == null )
        {
            return NotFound();
        }
        return Ok( roomType );
    }

    [HttpGet]
    public async Task<IActionResult> GetRooms()
    {
        List<RoomTypeDTO> roomTypes = await _roomTypeService.GetAll();
        return Ok( roomTypes );
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom( [FromBody] RoomTypeDTO roomType )
    {
        int newId = await _roomTypeService.Create( roomType );
        await _unitOfWork.CommitAsync();
        return CreatedAtAction( nameof( CreateRoom ), new { id = newId }, newId );
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateRoom( int id, [FromBody] RoomTypeRequestDTO roomDTO )
    {
        try
        {
            await _roomTypeService.Update( id, roomDTO );
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        catch ( KeyNotFoundException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteRoomType( int id )
    {
        await _roomTypeService.Delete( id );
        await _unitOfWork.CommitAsync();
        return NoContent();
    }

    [HttpPatch( "{id}/services" )]
    public async Task<IActionResult> AddServices( int id, [FromBody] List<int> serviceIds )
    {
        if ( serviceIds == null || !serviceIds.Any() )
            return BadRequest( "ServiceIds cannot be empty." );

        await _roomTypeService.AddService( id, serviceIds );
        return NoContent();
    }

    [HttpPatch( "{id}/amenities" )]
    public async Task<IActionResult> AddAmenity( int id, [FromBody] List<int> amenityIds )
    {

    }
}
