using Application.DTO;
using Application.Interface;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers;

[ApiController]
[Route( "api/properties" )]
public class PropertiesController : ControllerBase
{
    private readonly IPropertySevice _propertyService;
    private readonly IUnitOfWork _unitOfWork;

    public PropertiesController( IPropertySevice propertySevice, IUnitOfWork unitOfWork )
    {
        _propertyService = propertySevice;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetProperties()
    {
        List<PropertyDTO> properties = await _propertyService.GetAll();
        if ( properties.Count == 0 )
        {
            return NoContent();
        }
        return Ok( properties );
    }

    [HttpGet( "{id}" )]
    public async Task<IActionResult> GetProperty( int id )
    {
        PropertyDTO property = await _propertyService.GetById( id );
        if ( property == null )
        {
            return NotFound();
        }
        return Ok( property );
    }

    [HttpGet( "{id}/roomtypes" )]
    public async Task<IActionResult> GetRoomTypesProperty( int id )
    {
        List<RoomTypeDTO> roomTypeDTOs = await _propertyService.GetRoomTypesProperty( id );
        if ( roomTypeDTOs == null )
        {
            return NoContent();
        }
        return Ok( roomTypeDTOs );
    }

    [HttpPost]
    public async Task<IActionResult> CreateProperty( [FromBody] PropertyDTO property )
    {
        int newId = await _propertyService.Create( property );
        await _unitOfWork.CommitAsync();
        return CreatedAtAction( nameof( CreateProperty ), new { id = newId }, newId );
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> Update( int id, [FromBody] PropertyDTO property )
    {
        try
        {
            await _propertyService.Update( id, property );
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        catch ( KeyNotFoundException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteProperty( int id )
    {
        try
        {
            await _propertyService.Delete( id );
            await _unitOfWork.CommitAsync();
            return NoContent();
        }
        catch ( KeyNotFoundException ex )
        {
            return NotFound( ex.Message );
        }
    }
}
