using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers;

[ApiController]
[Route( "api/roomtypes" )]
public class RoomTypesController : ControllerBase
{
    private readonly IRoomTypeService _roomTypeService;

    public RoomTypesController( IRoomTypeService roomTypeService )
    {
        _roomTypeService = roomTypeService;
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
        int newId =  await _roomTypeService.Create( roomType )  ;
        return CreatedAtAction( nameof( CreateRoom ), new { id = newId}, newId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom( int id, [FromBody] RoomTypeDTO roomDTO )
    {
        try
        {
            await _roomTypeService.Update( id, roomDTO );
            return Ok();
        }
        catch ( KeyNotFoundException ex)
        {
            return NotFound( ex.Message );
        }
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteRoomType( int id )
    {
        await _roomTypeService.Delete( id );
        return NoContent();
    }

}
